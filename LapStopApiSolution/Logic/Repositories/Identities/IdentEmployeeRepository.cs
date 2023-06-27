using Microsoft.AspNetCore.Identity;

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

        public async Task<IdentityResult> ExeCreateAsync(IdentEmployee identEmployee, string rawPassword, ICollection<string?> employeeRoles)
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

        /// <summary>
        /// RefreshToken
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="refreshToken"></param>
        /// <param name="refreshTokenExpiryTime">Generated ONLY 1 time - NO updated</param>
        /// <returns></returns>
        public async Task<IdentityResult> ExeUpdateRefreshTokenAsync(IdentEmployee employee, string refreshToken, 
                                                                    DateTime? refreshTokenExpiryTime = null)
        {
            if (employee != null)
            {
                employee.RefreshToken = refreshToken;
                if (refreshTokenExpiryTime.HasValue)
                {
                    employee.RefreshTokenExpiryTime = refreshTokenExpiryTime.Value;
                }
                return await _userManager.UpdateAsync(employee);
            }
            return IdentityResult.Failed(new IdentityError() { Code = "NULL Value"});
        }

        public async Task<IdentEmployee?> FindByUsernameAsync(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                return await _userManager.FindByNameAsync(username);
            }
            return null;
        }

        public async Task<IList<string>> GetRolesOfEmployeeAsync(IdentEmployee employee)
        {
            return await _userManager.GetRolesAsync(employee);
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
