using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeAccountService : ServiceBase, IEmployeeAccountService
    {
        public EmployeeAccountService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public IEnumerable<EmployeeAccountDto> GetAll()
        {
            IEnumerable<EmployeeAccount> employeeAccounts = _repositoryManager.EmployeeAccount.GetAll(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<EmployeeAccountDto>>(employeeAccounts);
        }

        public EmployeeAccountDto? GetOneByEmployeeId(Guid employeeId)
        {
            if (_repositoryManager.Employee.IsValidId(employeeId) == false)
            {
                throw new ExNotFoundInDB(nameof(EmployeeAccountService), nameof(GetOneByEmployeeId), typeof(Employee), employeeId);
            }
            EmployeeAccount? employeeAccount = _repositoryManager.EmployeeAccount.GetOneByEmployeeId(isTrackChanges: false, employeeId);
            if (employeeAccount == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeAccountService), nameof(GetOneByEmployeeId), typeof(EmployeeAccount), employeeId);
            }
            return MappingToNewObj<EmployeeAccountDto>(employeeAccount);
        }
    }
}
