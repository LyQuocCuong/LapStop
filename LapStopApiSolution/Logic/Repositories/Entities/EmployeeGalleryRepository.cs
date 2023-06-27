namespace Repositories.Entities
{
    internal sealed class EmployeeGalleryRepository : AbstractEntityRepository<EmployeeGallery>, IEmployeeGalleryRepository
    {
        public EmployeeGalleryRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }

        public async Task<IEnumerable<EmployeeGallery>> GetAllByEmployeeIdAsync(bool isTrackChanges, Guid employeeId)
        {
            return await FindByCondition(isTrackChanges, e => e.EmployeeId == employeeId).ToListAsync();
        }
    }
}
