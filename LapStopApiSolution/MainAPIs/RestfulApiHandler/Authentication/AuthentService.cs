using Contracts.Authentication;
using Domains.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogicServices.Authentication
{
    public class AuthentService : IAuthentService
    {
        private readonly IConfiguration _configuration;
        private IdentEmployee _employee;
        private readonly UserManager<IdentEmployee> _userManager;

        public AuthentService(IConfiguration configuration,
            UserManager<IdentEmployee> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> CreateToken(string username)
        {
            _employee = await _userManager.FindByNameAsync(username);
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(); 
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials() 
        { 
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET")); 
            var secret = new SymmetricSecurityKey(key); 
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256); 
        }

        private async Task<List<Claim>> GetClaims() 
        { 
            var claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Name, _employee.UserName) 
            }; 
            var roles = await _userManager.GetRolesAsync(_employee); 
            foreach (var role in roles) 
            { 
                claims.Add(new Claim(ClaimTypes.Role, role)); 
            } 
            return claims; 
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
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
