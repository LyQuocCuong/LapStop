using Microsoft.AspNetCore.Identity;

namespace Repositories.Identities
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

        public async Task<IdentityResult> CreateAsync(IdentEmployee identEmployee, string rawPassword, ICollection<string?> employeeRoles)
        {
            IdentityResult result = await _userManager.CreateAsync(identEmployee, rawPassword);
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

    }
}
