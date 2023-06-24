using Domains.IdentityModels;
using DTO.Input.FromBody.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Contracts.IRepositories.IdentityModels
{
    public interface IIdentEmployeeRepository
    {
        Task<IdentityResult> Create(IdentEmployee identEmployee, string rawPassword, ICollection<string?> employeeRoles);
        Task<bool> Validate(EmployeeForAuthentDto authentDto);
    }
}