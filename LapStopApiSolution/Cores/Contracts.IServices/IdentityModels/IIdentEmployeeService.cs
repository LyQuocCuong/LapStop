using DTO.Input.FromBody.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Contracts.IServices.IdentityModels
{
    public interface IIdentEmployeeService
    {
        Task<IdentityResult> CreateAsync(EmployeeForRegistrationDto registrationDto, string rawPassword);

        Task<bool> IsValidAuthentData(AuthentDto authentDto);
    }
}
