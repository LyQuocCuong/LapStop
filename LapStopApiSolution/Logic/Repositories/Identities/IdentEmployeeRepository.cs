using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Repositories.Identities
{
    internal sealed class IdentEmployeeRepository : AbstractIndentityRepository, IIdentEmployeeRepository
    {
        private readonly UserManager<IdentEmployee> _userManager;

        public IdentEmployeeRepository(IDomainRepositories domainRepositories,
                                    UserManager<IdentEmployee> userManager) 
            : base(domainRepositories)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(IdentEmployee identEmployee, string rawPassword, ICollection<string?> employeeRoles)
        {
            IdentityResult result = await _userManager.CreateAsync(identEmployee, rawPassword);
            if (result.Succeeded)
            {
                foreach(string? role in employeeRoles)
                {
                    if (!string.IsNullOrEmpty(role) && 
                        await IdentityRepositories.IdentRole.IsRoleExistsAsync(role))
                    {
                        await _userManager.AddToRoleAsync(identEmployee, role);
                    }
                }
            }
            return result;
        }

        public async Task<IdentEmployee?> FindByUsernameAsync(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                return await _userManager.FindByNameAsync(username);
            }
            return null;
        }

        public async Task<bool> IsValidAuthentData(string username, string password)
        {
            IdentEmployee? employee = await FindByUsernameAsync(username);
            if (employee != null && !string.IsNullOrEmpty(password))
            {
                return await _userManager.CheckPasswordAsync(employee, password);
            }
            return false;
        }

        public async Task<List<Claim>> GetClaimsInfo(string username)
        {
            List<Claim> claimsInfo = new List<Claim>();

            IdentEmployee? employee = await FindByUsernameAsync(username);
            if (employee != null)
            {
                claimsInfo.Add(new Claim(ClaimTypes.Name, username));

                var rolesOfEmployee = await _userManager.GetRolesAsync(employee);
                foreach (var role in rolesOfEmployee)
                {
                    claimsInfo.Add(new Claim(ClaimTypes.Role, role));
                }
            }
            return claimsInfo;
        }

    }
}
