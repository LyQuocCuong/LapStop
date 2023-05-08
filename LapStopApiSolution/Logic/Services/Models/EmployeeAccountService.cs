using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeAccountService : ServiceBase, IEmployeeAccountService
    {
        public EmployeeAccountService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<EmployeeAccountDto>> GetAllAsync()
        {
            IEnumerable<EmployeeAccount> employeeAccounts = await _repositoryManager.EmployeeAccount.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<EmployeeAccountDto>>(employeeAccounts);
        }

        public async Task<EmployeeAccountDto?> GetOneByEmployeeIdAsync(Guid employeeId)
        {
            if (await _repositoryManager.Employee.IsValidIdAsync(employeeId) == false)
            {
                throw new ExNotFoundInDB(nameof(EmployeeAccountService), nameof(GetOneByEmployeeIdAsync), typeof(Employee), employeeId);
            }
            EmployeeAccount? employeeAccount = await _repositoryManager.EmployeeAccount.GetOneByEmployeeIdAsync(isTrackChanges: false, employeeId);
            if (employeeAccount == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeAccountService), nameof(GetOneByEmployeeIdAsync), typeof(EmployeeAccount), employeeId);
            }
            return MappingToNewObj<EmployeeAccountDto>(employeeAccount);
        }
    }
}
