using Microsoft.AspNetCore.Identity;

namespace Contracts.IServices.IdentityModels
{
    public interface IIdentEmployeeService
    {
        Task<IdentityResult> RegisterEmployee(EmployeeForRegistrationDto registrationDto);
    }
}
