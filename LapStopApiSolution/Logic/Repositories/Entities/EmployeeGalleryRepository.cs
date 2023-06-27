namespace Repositories.Entities
{
    internal sealed class EmployeeGalleryRepository : AbstractEntityRepository<EmployeeGallery>, IEmployeeGalleryRepository
    {
        public EmployeeGalleryRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }

        public async Task<IEnumerable<EmployeeGallery>> GetAllByEmployeeIdAsync(bool isTrackChanges, Guid employeeId)
        {
            return await FindByCondition(isTrackChanges, e => e.EmployeeId == employeeId).ToListAsync();
        }
    }
}
