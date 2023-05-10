using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class EmployeeService : ServiceBase, IEmployeeService
    {
        public EmployeeService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        private async Task<Employee> GetEmployeeAndCheckIfItExists(bool isTrackChanges, Guid employeeId)
        {
            Employee? employee = await _repositoryManager.Employee.GetOneByIdAsync(isTrackChanges, employeeId);
            if (employee == null)
            {
                throw new ExNotFoundInDB(nameof(EmployeeService), nameof(GetEmployeeAndCheckIfItExists), typeof(Employee), employeeId);
            }
            return employee;
        }

        public async Task<PagedList<EmployeeDto>> GetAllAsync(EmployeeParameter parameter)
        {
            IEnumerable<Employee> employees = await _repositoryManager.Employee.GetAllAsync(isTrackChanges: false, parameter);
            int totalRecords = await _repositoryManager.Employee.CountAllAsync(parameter);
            
            var sourceDto = MappingToNewObj<IEnumerable<EmployeeDto>>(employees);
            return new PagedList<EmployeeDto>(sourceDto.ToList(), totalRecords, parameter.PageNumber, parameter.PageSize); ;
        }

        public async Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: false, employeeId);
            return MappingToNewObj<EmployeeDto>(employee);
        }

        public async Task<EmployeeForUpdateDto> GetDtoForPatchAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: false, employeeId);
            return MappingToNewObj<EmployeeForUpdateDto>(employee);
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
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: true, employeeId);
            MappingToExistingObj(updatedDto, employee);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: true, employeeId);
            _repositoryManager.Employee.Delete(employee);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
