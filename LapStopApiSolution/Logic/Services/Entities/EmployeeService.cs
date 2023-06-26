namespace Services.Entities
{
    internal sealed class EmployeeService : AbstractService, IEmployeeService
    {
        public EmployeeService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
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

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(EmployeeRequestParam parameter)
        {
            IEnumerable<Employee> employees = await EntityRepositories.Employee.GetAllAsync(isTrackChanges: false, parameter);
            int totalRecords = await EntityRepositories.Employee.CountAllAsync(parameter);
            
            var sourceDto = UtilServices.Mapper.ExecuteMapping<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            var shapedData = UtilServices.DataShaperForEmployee.Execute(sourceDto, parameter.ShapingProps);

            //return new PagedList<DynamicModel>(shapedData.ToList(), totalRecords, parameter.PageNumber, parameter.PageSize); ;
            return new PagedList<ExpandoForXmlObject>(new List<ExpandoForXmlObject>(), 0, 0, 0);
        }

        public async Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: false, employeeId);
            return UtilServices.Mapper.ExecuteMapping<Employee, EmployeeDto>(employee);
        }

        public async Task<EmployeeForUpdateDto> GetDtoForPatchAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: false, employeeId);
            return UtilServices.Mapper.ExecuteMapping<Employee, EmployeeForUpdateDto>(employee);
        }

        public async Task<bool> IsValidIdAsync(Guid employeeId)
        {
            return await EntityRepositories.Employee.IsValidIdAsync(employeeId);
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeForCreationDto creationDto)
        {
            Employee newEmployee = UtilServices.Mapper.ExecuteMapping<EmployeeForCreationDto, Employee>(creationDto);
            EntityRepositories.Employee.Create(newEmployee);
            await SaveChangesToDatabaseAsync();

            return UtilServices.Mapper.ExecuteMapping<Employee, EmployeeDto>(newEmployee);
        }

        public async Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto updatedDto)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: true, employeeId);
            UtilServices.Mapper.ExecuteMapping<EmployeeForUpdateDto, Employee>(updatedDto, employee);
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
