namespace Services.Models
{
    internal sealed class EmployeeRoleService : ServiceBase, IEmployeeRoleService
    {
        public EmployeeRoleService(ILogService logService,
                                   IMappingService mappingService,
                                   IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<IEnumerable<EmployeeRoleDto>> GetAllAsync()
        {
            IEnumerable<EmployeeRole> employeeRoles = await _repositoryManager.EmployeeRole.GetAllAsync(isTrackChanges: false);
            return _mappingService.Map<IEnumerable<EmployeeRole>, IEnumerable<EmployeeRoleDto>>(employeeRoles);
        }

        public async Task<EmployeeRoleDto?> GetOneByIdAsync(Guid employeeRoleId)
        {
            EmployeeRole? employeeRole = await _repositoryManager.EmployeeRole.GetOneByIdAsync(isTrackChanges: false, employeeRoleId);
            if (employeeRole == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeRoleService), nameof(GetOneByIdAsync), typeof(EmployeeRole), employeeRoleId);
            }
            return _mappingService.Map<EmployeeRole, EmployeeRoleDto>(employeeRole);
        }
    }
}
