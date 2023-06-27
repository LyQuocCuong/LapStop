using Domains.Identities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Contracts.IRepositories.Identities
{
    public interface IIdentEmployeeRepository
    {
        Task<IdentityResult> CreateAsync(IdentEmployee identEmployee, string rawPassword, ICollection<string?> employeeRoles);
        
        Task<IdentEmployee?> FindByUsernameAsync(string username);
        
        Task<bool> IsValidAuthentData(string username, string password);

        Task<List<Claim>> GetClaimsInfo(string username);
    }
}