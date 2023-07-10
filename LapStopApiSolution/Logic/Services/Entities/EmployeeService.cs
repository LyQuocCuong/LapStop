using Common.Functions;
using DTO.Output.ApiResponses.Bases;
using DTO.Output.ApiResponses.ErrorBadRequest;

namespace Services.Entities
{
    internal sealed class EmployeeService : AbstractService, IEmployeeService
    {
        public EmployeeService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        private async Task<Employee> GetEmployeeAndCheckIfItExists(bool isTrackChanges, Guid employeeId)
        {
            Employee? employee = await EntityRepositories.Employee.GetOneByIdAsync(isTrackChanges, employeeId);
            if (employee == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeService), nameof(GetEmployeeAndCheckIfItExists), typeof(Employee), employeeId);
            }
            return employee;
        }

        public async Task<ApiResponseBase> GetAllAsync(EmployeeRequestParam parameter)
        {
            if (parameter.MinAge > parameter.MaxAge)
            {
                return new EmployeeBadRequestResponse(
                        message: CommonFunctions.DisplayErrors.ReturnInvalidAgeRangeMessage);
            }

            IEnumerable<Employee> employees = await EntityRepositories.Employee
                                                            .GetAllAsync(isTrackChanges: false, parameter);
            
            int totalRecords = await EntityRepositories.Employee.CountAllAsync(parameter);
            
            var sourceDto = UtilityServices.Mapper
                                .ExecuteMapping<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            var shapedData = UtilityServices.DataShaperForEmployee
                                .Execute(sourceDto, parameter.ShapingProps);

            var result = new PagedList<ExpandoForXmlObject>(
                sourceData: shapedData.ToList(), 
                totalRecords: totalRecords, 
                pageNumber: parameter.PageNumber, 
                pageSize: parameter.PageSize);

            return new ApiOkResponse<PagedList<ExpandoForXmlObject>>(result);
        }

        public async Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: false, employeeId);
            
            return UtilityServices.Mapper.ExecuteMapping<Employee, EmployeeDto>(employee);
        }

        public async Task<EmployeeForUpdateDto> GetDtoForPatchAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: false, employeeId);
            return UtilityServices.Mapper.ExecuteMapping<Employee, EmployeeForUpdateDto>(employee);
        }

        public async Task<bool> IsValidIdAsync(Guid employeeId)
        {
            return await EntityRepositories.Employee.IsValidIdAsync(employeeId);
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeForCreationDto creationDto)
        {
            Employee newEmployee = UtilityServices.Mapper.ExecuteMapping<EmployeeForCreationDto, Employee>(creationDto);
            EntityRepositories.Employee.Create(newEmployee);
            await SaveChangesToDatabaseAsync();

            return UtilityServices.Mapper.ExecuteMapping<Employee, EmployeeDto>(newEmployee);
        }

        public async Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto updatedDto)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: true, employeeId);
            UtilityServices.Mapper.ExecuteMapping<EmployeeForUpdateDto, Employee>(updatedDto, employee);
            await SaveChangesToDatabaseAsync();
        }

        public async Task DeleteAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: true, employeeId);
            EntityRepositories.Employee.Delete(employee);
            await SaveChangesToDatabaseAsync();
        }
    }
}
