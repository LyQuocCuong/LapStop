using Domains.Identities;
using Microsoft.AspNetCore.Identity;

namespace Contracts.IRepositories.Identities
{
    public interface IIdentEmployeeRepository
    {
        Task<IdentityResult> CreateAsync(IdentEmployee identEmployee, string rawPassword, ICollection<string?> employeeRoles);

        /// <summary>
        /// Update the RefreshToken, refreshTokenExpiryTime generated ONLY 1 time - NO updated
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="refreshToken"></param>
        /// <param name="refreshTokenExpiryTime">Generated ONLY 1 time - NO updated</param>
        /// <returns></returns>
        Task<IdentityResult> ExeUpdateRefreshTokenAsync(IdentEmployee employee, string refreshToken, DateTime? refreshTokenExpiryTime = null);
        
        Task<IdentEmployee?> FindByUsernameAsync(string username);

        Task<IList<string>> GetRolesOfEmployeeAsync(IdentEmployee employee);

        Task<bool> IsValidAuthentData(string username, string password);

    }
}