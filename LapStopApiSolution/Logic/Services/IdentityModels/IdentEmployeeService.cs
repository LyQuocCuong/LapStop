using Contracts.IServices.IdentityModels;
using Domains.IdentityModels;
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

        public async Task<IdentityResult> RegisterEmployee(EmployeeForRegistrationDto registrationDto)
        {
            var identEmployee = _mappingService.Map<EmployeeForRegistrationDto, IdentEmployee>(registrationDto);
            return await _repositoryManager.IdentEmployee.RegisterEmployee(identEmployee, registrationDto.Roles);
        }
    }
}
