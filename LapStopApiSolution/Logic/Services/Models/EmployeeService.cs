using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeService : ServiceBase, IEmployeeService
    {
        public EmployeeService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            IEnumerable<Employee> employees = _repositoryManager.Employee.GetAll(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDto? GetOneById(Guid employeeId)
        {
            Employee? employee = _repositoryManager.Employee.GetOneById(isTrackChanges: false, employeeId);
            if (employee == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeService), nameof(GetOneById), typeof(Employee), employeeId);
            }
            return MappingToNewObj<EmployeeDto>(employee);
        }

        public bool IsValidId(Guid employeeId)
        {
            return _repositoryManager.Employee.IsValidId(employeeId);
        }
    }
}
