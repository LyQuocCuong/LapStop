using DTO.Input.FromBody.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Contracts.IServices.IdentityModels
{
    public interface IIdentEmployeeService
    {
        Task<IdentityResult> Create(EmployeeForRegistrationDto registrationDto, string rawPassword);
        Task<bool> Validate(EmployeeForAuthentDto authentDto);
    }
}
