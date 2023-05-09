using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
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

        public async Task<EmployeeDto> CreateAsync(EmployeeForCreationDto creationDto)
        {
            Employee newEmployee = MappingToNewObj<Employee>(creationDto);
            _repositoryManager.Employee.Create(newEmployee);
            await _repositoryManager.SaveChangesAsync();

            return MappingToNewObj<EmployeeDto>(newEmployee);
        }

        public async Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto updatedDto)
        {
            Employee? employee = await _repositoryManager.Employee.GetOneByIdAsync(isTrackChanges: true, employeeId);
            if (employee == null)
            {
                throw new ExNotFoundInDB(nameof(BrandService), nameof(UpdateAsync), typeof(Employee), employeeId);
            }
            MappingToExistingObj(updatedDto, employee);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid employeeId)
        {
            Employee? employee = await _repositoryManager.Employee.GetOneByIdAsync(isTrackChanges: true, employeeId);
            if (employee == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeService), nameof(DeleteAsync), typeof(Employee), employeeId);
            }
            _repositoryManager.Employee.Delete(employee);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
