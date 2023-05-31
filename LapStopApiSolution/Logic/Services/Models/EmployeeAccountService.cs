using Common.Models.Exceptions;
using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class EmployeeAccountService : ServiceBase, IEmployeeAccountService
    {
        public EmployeeAccountService(ILogService logService,
                                       IMappingService mappingService,
                                       IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<IEnumerable<EmployeeAccountDto>> GetAllAsync()
        {
            IEnumerable<EmployeeAccount> employeeAccounts = await _repositoryManager.EmployeeAccount.GetAllAsync(isTrackChanges: false);
            return _mappingService.Map<IEnumerable<EmployeeAccount>, IEnumerable<EmployeeAccountDto>>(employeeAccounts);
        }

        public async Task<EmployeeAccountDto?> GetOneByEmployeeIdAsync(Guid employeeId)
        {
            if (await _repositoryManager.Employee.IsValidIdAsync(employeeId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeAccountService), nameof(GetOneByEmployeeIdAsync), typeof(Employee), employeeId);
            }
            EmployeeAccount? employeeAccount = await _repositoryManager.EmployeeAccount.GetOneByEmployeeIdAsync(isTrackChanges: false, employeeId);
            if (employeeAccount == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeAccountService), nameof(GetOneByEmployeeIdAsync), typeof(EmployeeAccount), employeeId);
            }
            return _mappingService.Map<EmployeeAccount, EmployeeAccountDto>(employeeAccount);
        }
    }
}
