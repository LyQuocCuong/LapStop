using Contracts.IRepositories;
using Contracts.IRepositories.Managers;
using Contracts.Utilities.Authentication;
using Domains.Identities;
using DTO.Output.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RestfulApiHandler.ImpServices.Authentication
{
    public sealed class AuthentEmployeeService : IAuthentService
    {
        private readonly IConfiguration _configuration;
        private readonly IIdentityRepositoryManager _identityRepositories;

        public AuthentEmployeeService(IConfiguration configuration,
                              IDomainRepositories domainRepositories)
        {
            _configuration = configuration;
            _identityRepositories = domainRepositories.IdentityRepositories;
        }


        public async Task<TokensDto> GenerateTokens(string username)
        {
            IdentEmployee? employee = await _identityRepositories.IdentEmployee.FindByUsernameAsync(username);
            if (employee != null)
            {
                TokensDto newTokens = new TokensDto()
                {
                    AccessToken = await GenerateJwtToken(employee),
                    RefreshToken = GenerateRefreshToken(),
                };

                DateTime refreshTokenExpiryTime = DateTime.Now.AddDays(7);
                var result = await _identityRepositories.IdentEmployee
                                        .ExeUpdateRefreshTokenAsync(employee, newTokens.RefreshToken, refreshTokenExpiryTime);
                if (result.Succeeded)
                {
                    return newTokens;
                }
            }
            return new TokensDto();
        }

        public async Task<TokensDto> ProcessExpiredAccessToken(TokensDto inputTokenDto)
        {
            if (!string.IsNullOrEmpty(inputTokenDto.AccessToken))
            {
                ClaimsPrincipal principal = GetPrincipalFromExpiredToken(inputTokenDto.AccessToken);
                if (principal.Identity != null && !string.IsNullOrEmpty(principal.Identity.Name))
                {
                    IdentEmployee? employee = await _identityRepositories.IdentEmployee.FindByUsernameAsync(principal.Identity.Name);
                    if (employee != null
                        && employee.RefreshToken == inputTokenDto.RefreshToken
                        && employee.RefreshTokenExpiryTime > DateTime.Now)
                    {
                        // re-generate Tokens (NOT update expiration of RefreshToken)
                        inputTokenDto.AccessToken = await GenerateJwtToken(employee);
                        inputTokenDto.RefreshToken = GenerateRefreshToken();

                        var result = await _identityRepositories.IdentEmployee.ExeUpdateRefreshTokenAsync(employee, inputTokenDto.RefreshToken, null);

                        if (result.Succeeded)
                        {
                            return inputTokenDto;
                        }
                    }
                    //throw new RefreshTokenBadRequest(); // Invalid RefreshToken
                }
            }
            return new TokensDto();
        }

        private async Task<string> GenerateJwtToken(IdentEmployee employee)
        {
            var signingCredentials = GetSigningCredentials();

            List<Claim> claimsInfo = await GetClaimsInfo(employee);

            var tokenOptions = GenerateTokenOptions(signingCredentials, claimsInfo);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<List<Claim>> GetClaimsInfo(IdentEmployee employee)
        {
            List<Claim> claimsInfo = new List<Claim>();
            if (employee != null)
            {
                claimsInfo.Add(new Claim(ClaimTypes.Name, employee.UserName));

                var rolesOfEmployee = await _identityRepositories.IdentEmployee.GetRolesOfEmployeeAsync(employee);
                foreach (var role in rolesOfEmployee)
                {
                    claimsInfo.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            return claimsInfo;
        }

        private SigningCredentials? GetSigningCredentials()
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("SECRET")))
            {
                return null;
            }
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials? signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                claims: claims,
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string expiredToken)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"]
            };
            SecurityToken securityToken;
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(expiredToken, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }


    }
}
