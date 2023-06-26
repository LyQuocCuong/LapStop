namespace Services.Entities
{
    internal sealed class EmployeeStatusService : AbstractService, IEmployeeStatusService
    {
        public EmployeeStatusService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }

        public async Task<IEnumerable<EmployeeStatusDto>> GetAllAsync()
        {
            IEnumerable<EmployeeStatus> employeeStatuses = await EntityRepositories.EmployeeStatus.GetAllAsync(isTrackChanges: false);
            return UtilServices.Mapper.ExecuteMapping<IEnumerable<EmployeeStatus>, IEnumerable<EmployeeStatusDto>>(employeeStatuses);
        }

        public async Task<EmployeeStatusDto?> GetOneByIdAsync(Guid employeeStatusId)
        {
            EmployeeStatus? employeeStatus = await EntityRepositories.EmployeeStatus.GetOneByIdAsync(isTrackChanges: false, employeeStatusId);
            if (employeeStatus == null)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeStatus), nameof(GetOneByIdAsync), typeof(EmployeeStatus), employeeStatusId);
            }
            return UtilServices.Mapper.ExecuteMapping<EmployeeStatus, EmployeeStatusDto>(employeeStatus); 
        }
    }
}
