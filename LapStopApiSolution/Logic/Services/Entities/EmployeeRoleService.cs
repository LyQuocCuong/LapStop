namespace Services.Entities
{
    internal sealed class EmployeeRoleService : AbstractService, IEmployeeRoleService
    {
        public EmployeeRoleService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        public async Task<IEnumerable<EmployeeRoleDto>> GetAllAsync()
        {
            IEnumerable<EmployeeRole> employeeRoles = await EntityRepositories.EmployeeRole.GetAllAsync(isTrackChanges: false);
            return UtilityServices.Mapper.ExecuteMapping<IEnumerable<EmployeeRole>, IEnumerable<EmployeeRoleDto>>(employeeRoles);
        }

        public async Task<EmployeeRoleDto?> GetOneByIdAsync(Guid employeeRoleId)
        {
            EmployeeRole? employeeRole = await EntityRepositories.EmployeeRole.GetOneByIdAsync(isTrackChanges: false, employeeRoleId);
            if (employeeRole == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeRoleService), nameof(GetOneByIdAsync), typeof(EmployeeRole), employeeRoleId);
            }
            return UtilityServices.Mapper.ExecuteMapping<EmployeeRole, EmployeeRoleDto>(employeeRole);
        }
    }
}
