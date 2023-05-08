using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeService : ServiceBase, IEmployeeService
    {
        public EmployeeService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            IEnumerable<Employee> employees = await _repositoryManager.Employee.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId)
        {
            Employee? employee = await _repositoryManager.Employee.GetOneByIdAsync(isTrackChanges: false, employeeId);
            if (employee == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeService), nameof(GetOneByIdAsync), typeof(Employee), employeeId);
            }
            return MappingToNewObj<EmployeeDto>(employee);
        }

        public async Task<bool> IsValidIdAsync(Guid employeeId)
        {
            return await _repositoryManager.Employee.IsValidIdAsync(employeeId);
        }
    }
}
