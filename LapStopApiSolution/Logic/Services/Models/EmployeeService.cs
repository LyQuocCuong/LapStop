namespace Services.Models
{
    internal sealed class EmployeeService : ServiceBase, IEmployeeService
    {
        private readonly IDataShaperService<EmployeeDto, ExpandoForXmlObject> _dataShaper;

        public EmployeeService(ILogService logService,
                            IMappingService mappingService,
                            IRepositoryManager repositoryManager,
                            IDataShaperService<EmployeeDto, ExpandoForXmlObject> dataShaper)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
            _dataShaper = dataShaper;
        }

        private async Task<Employee> GetEmployeeAndCheckIfItExists(bool isTrackChanges, Guid employeeId)
        {
            Employee? employee = await _repositoryManager.Employee.GetOneByIdAsync(isTrackChanges, employeeId);
            if (employee == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeService), nameof(GetEmployeeAndCheckIfItExists), typeof(Employee), employeeId);
            }
            return employee;
        }

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(EmployeeRequestParam parameter)
        {
            IEnumerable<Employee> employees = await _repositoryManager.Employee.GetAllAsync(isTrackChanges: false, parameter);
            int totalRecords = await _repositoryManager.Employee.CountAllAsync(parameter);
            
            var sourceDto = _mappingService.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            var shapedData = _dataShaper.Execute(sourceDto, parameter.ShapingProps);

            //return new PagedList<DynamicModel>(shapedData.ToList(), totalRecords, parameter.PageNumber, parameter.PageSize); ;
            return new PagedList<ExpandoForXmlObject>(new List<ExpandoForXmlObject>(), 0, 0, 0);
        }

        public async Task<EmployeeDto?> GetOneByIdAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: false, employeeId);
            return _mappingService.Map<Employee, EmployeeDto>(employee);
        }

        public async Task<EmployeeForUpdateDto> GetDtoForPatchAsync(Guid employeeId)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: false, employeeId);
            return _mappingService.Map<Employee, EmployeeForUpdateDto>(employee);
        }

        public async Task<bool> IsValidIdAsync(Guid employeeId)
        {
            return await _repositoryManager.Employee.IsValidIdAsync(employeeId);
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeForCreationDto creationDto)
        {
            Employee newEmployee = _mappingService.Map<EmployeeForCreationDto, Employee>(creationDto);
            _repositoryManager.Employee.Create(newEmployee);
            await _repositoryManager.SaveChangesAsync();

            return _mappingService.Map<Employee, EmployeeDto>(newEmployee);
        }

        public async Task UpdateAsync(Guid employeeId, EmployeeForUpdateDto updatedDto)
        {
            Employee employee = await GetEmployeeAndCheckIfItExists(isTrackChanges: true, employeeId);
            _mappingService.Map<EmployeeForUpdateDto, Employee>(updatedDto, employee);
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
