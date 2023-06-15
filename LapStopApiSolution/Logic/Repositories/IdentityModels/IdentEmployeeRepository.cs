using Contracts.IRepositories.IdentityModels;
using Domains.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace Repositories.IdentityModels
{
    internal sealed class IdentEmployeeRepository : IIdentEmployeeRepository
    {
        private readonly UserManager<IdentEmployee> _userManager;
        private readonly RoleManager<IdentRole> _roleManager;

        public IdentEmployeeRepository(UserManager<IdentEmployee> userManager, 
                                       RoleManager<IdentRole> roleManager) 
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterEmployee(IdentEmployee identEmployee, ICollection<string?> employeeRoles)
        {
            IdentityResult result = await _userManager.CreateAsync(identEmployee, identEmployee.PasswordHash);
            if (result.Succeeded)
            {
                foreach(string? role in employeeRoles)
                {
                    if (await _roleManager.RoleExistsAsync(role))
                    {
                        await _userManager.AddToRoleAsync(identEmployee, role);
                    }
                }
            }
            return result;
        }
    }
}
