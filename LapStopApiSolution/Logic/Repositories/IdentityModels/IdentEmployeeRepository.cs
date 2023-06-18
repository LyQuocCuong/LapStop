using Contracts.IRepositories.IdentityModels;
using Domains.IdentityModels;
using DTO.Input.FromBody.Authentication;
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

        public async Task<IdentityResult> Create(IdentEmployee identEmployee, ICollection<string?> employeeRoles)
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

        public async Task<bool> Validate(EmployeeForAuthentDto authentDto)
        {
            var employee = await _userManager.FindByNameAsync(authentDto.Username);
            var result = (employee != null && 
                          await _userManager.CheckPasswordAsync(employee, authentDto.Password));
            return result;
        }
    }
}
