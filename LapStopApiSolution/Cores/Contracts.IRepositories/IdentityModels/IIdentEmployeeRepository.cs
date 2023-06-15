using Domains.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace Contracts.IRepositories.IdentityModels
{
    public interface IIdentEmployeeRepository
    {
        Task<IdentityResult> RegisterEmployee(IdentEmployee identEmployee, ICollection<string?> employeeRoles);
    }
}