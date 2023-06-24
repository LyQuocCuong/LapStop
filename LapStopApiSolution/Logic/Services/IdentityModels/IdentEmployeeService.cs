using Contracts.IServices.IdentityModels;
using Domains.IdentityModels;
using DTO.Input.FromBody.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Services.IdentityModels
{
    internal sealed class IdentEmployeeService : ServiceBase, IIdentEmployeeService
    {
        public IdentEmployeeService(ILogService logService, 
                                    IMappingService mappingService, 
                                    IRepositoryManager repositoryManager) 
            : base(logService, mappingService, repositoryManager)
        {
        }

        public async Task<IdentityResult> Create(EmployeeForRegistrationDto registrationDto, string rawPassword)
        {
            var identEmployee = _mappingService.Map<EmployeeForRegistrationDto, IdentEmployee>(registrationDto);
            return await _repositoryManager.IdentEmployee.Create(identEmployee, rawPassword, registrationDto.Roles);
        }

        public async Task<bool> Validate(EmployeeForAuthentDto authentDto)
        {
            return await _repositoryManager.IdentEmployee.Validate(authentDto);
        }
    }
}
