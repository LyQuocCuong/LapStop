namespace Services.Entities
{
    internal sealed class EmployeeGalleryService : AbstractService, IEmployeeGalleryService
    {
        public EmployeeGalleryService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }

        public async Task<IEnumerable<EmployeeGalleryDto>> GetAllByEmployeeIdAsync(Guid employeeId)
        {
            if (await EntityRepositories.Employee.IsValidIdAsync(employeeId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(EmployeeAccountService), nameof(GetAllByEmployeeIdAsync), typeof(Employee), employeeId);
            }
            IEnumerable<EmployeeGallery> employeeGalleries = await EntityRepositories.EmployeeGallery.GetAllByEmployeeIdAsync(isTrackChanges: false, employeeId);
            return UtilServices.Mapper.ExecuteMapping<IEnumerable<EmployeeGallery>, IEnumerable<EmployeeGalleryDto>>(employeeGalleries);
        }
    }
}
