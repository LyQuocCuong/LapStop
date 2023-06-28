using DTO.Input.FromBody.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Services.Identities
{
    internal sealed class IdentEmployeeService : AbstractService, IIdentEmployeeService
    {
        public IdentEmployeeService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        public async Task<IdentityResult> CreateAsync(EmployeeForRegistrationDto registrationDto, string rawPassword)
        {
            var identEmployee = UtilityServices.Mapper.ExecuteMapping<EmployeeForRegistrationDto, IdentEmployee>(registrationDto);
            return await IdentityRepositories.IdentEmployee.ExeCreateAsync(identEmployee, rawPassword, registrationDto.Roles);
        }

        public async Task<bool> IsValidAuthentData(AuthentDto authentDto)
        {
            return await IdentityRepositories.IdentEmployee.IsValidAuthentData(authentDto.Username, authentDto.Password);
        }

    }
}
