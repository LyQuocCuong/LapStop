using Common.Variables;
using Contracts.IRepositories;
using Contracts.IRepositories.Managers;
using Contracts.Utilities.Authentication;
using Domains.Identities;
using DTO.Output.Token;
using Microsoft.IdentityModel.Tokens;
using RestfulApiHandler.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RestfulApiHandler.ImpServices.Authentication
{
    public sealed class AuthentEmployeeService : IAuthentService
    {
        private readonly IIdentityRepositoryManager _identityRepositories;

        public AuthentEmployeeService(IDomainRepositories domainRepositories)
        {
            _identityRepositories = domainRepositories.IdentityRepositories;
        }

        public async Task<TokensDto> GenerateTokens(string username)
        {
            IdentEmployee? employee = await _identityRepositories.IdentEmployee
                                                .FindByUsernameAsync(username);
            if (employee != null)
            {
                TokensDto newTokens = new TokensDto()
                {
                    AccessToken = await GenerateJwtToken(employee),
                    RefreshToken = GenerateRefreshToken(),
                };
                var result = await _identityRepositories.IdentEmployee
                                        .ExeUpdateRefreshTokenAsync
                                            (employee,newTokens.RefreshToken, 
                                            CommonVariables.RefreshTokenConfig.ExpirationTime);
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
                    IdentEmployee? employee = await _identityRepositories.IdentEmployee
                                                        .FindByUsernameAsync(principal.Identity.Name);
                    if (employee != null
                        && employee.RefreshToken == inputTokenDto.RefreshToken
                        && employee.RefreshTokenExpiryTime > DateTime.Now)
                    {
                        // re-generate Tokens
                        inputTokenDto.AccessToken = await GenerateJwtToken(employee);
                        inputTokenDto.RefreshToken = GenerateRefreshToken();

                        // NOT update expiration of RefreshToken
                        var result = await _identityRepositories.IdentEmployee
                                                .ExeUpdateRefreshTokenAsync
                                                    (employee, inputTokenDto.RefreshToken, null);

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

        private static SigningCredentials? GetSigningCredentials()
        {
            var key = CommonVariables.JwtTokenConfig.SecretKeyUTF8;
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, CommonVariables.JwtTokenConfig.AlgorithmForSignature);
        }

        private static JwtSecurityToken GenerateTokenOptions(SigningCredentials? signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: CommonVariables.JwtTokenConfig.ValidIssuer,
                audience: CommonVariables.JwtTokenConfig.ValidAudience,
                expires: CommonVariables.JwtTokenConfig.ExpirationTime,
                claims: claims,
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        private static ClaimsPrincipal GetPrincipalFromExpiredToken(string expiredToken)
        {
            var tokenValidationParameters = RestfulApiHelper.GetDefaultTokenValidationParams();

            // Due to validating an ExpiredToken, MUST turn off ValidateLifeTime.
            // If not, an lifetime exception thrown
            tokenValidationParameters.ValidateLifetime = false;

            SecurityToken securityToken;
            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsPrincipal principal = tokenHandler.ValidateToken(expiredToken, 
                                            tokenValidationParameters, out securityToken);
            
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null ||
                !jwtSecurityToken.Header.Alg
                                .Equals(CommonVariables.JwtTokenConfig.AlgorithmForSignature, 
                                        StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }


    }
}
