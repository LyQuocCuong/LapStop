using Contracts.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestfulApiHandler.ImpServices.Authentication
{
    public class AuthentService<TIdentityUser>  : IAuthentService<TIdentityUser> where TIdentityUser : IdentityUser<Guid>
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<TIdentityUser> _userManager;

        public AuthentService(IConfiguration configuration,
                                UserManager<TIdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> CreateToken(string username)
        {
            TIdentityUser identUserInfo = await _userManager.FindByNameAsync(username);

            var claims = await GetClaims(identUserInfo);
            var signingCredentials = GetSigningCredentials();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private async Task<List<Claim>> GetClaims(TIdentityUser identUserInfo)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, identUserInfo.UserName)
            };
            var userRoles = await _userManager.GetRolesAsync(identUserInfo);
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
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
