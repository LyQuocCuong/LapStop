using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomedExceptions;

namespace Services.Models
{
    internal sealed class EmployeeService : ServiceBase, IEmployeeService
    {
        public EmployeeService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<EmployeeDto> GetAll(bool isTrackChanges)
        {
            List<Employee> employees = _repositoryManager.Employee.GetAll(isTrackChanges);
            return MappingToNewObj<List<EmployeeDto>>(employees);
        }

        public EmployeeDto? GetById(bool isTrackChanges, Guid id)
        {
            Employee? employee = _repositoryManager.Employee.GetById(isTrackChanges, id);
            if (employee == null)
            {
                throw new NotFoundException404(nameof(EmployeeService), nameof(GetById), typeof(Employee), id);
            }
            return MappingToNewObj<EmployeeDto>(employee);
        }

        public bool IsValidEmployeeId(Guid id)
        {
            return _repositoryManager.Employee.IsValidEmployeeId(id);
        }
    }
}
