using Contracts.IRepositories;
using Contracts.IRepositories.Managers;
using Contracts.IServices.Managers;
using Contracts.Utilities.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public async Task<string> CreateToken(string username)
        {
            var claims = await _identityRepositories.IdentEmployee.GetClaimsInfo(username);
            
            var signingCredentials = GetSigningCredentials();
            
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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

    }
}
