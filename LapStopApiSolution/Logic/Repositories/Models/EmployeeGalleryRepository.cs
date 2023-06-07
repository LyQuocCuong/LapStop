namespace Repositories.Models
{
    internal sealed class EmployeeGalleryRepository : RepositoryBase<EmployeeGallery>, IEmployeeGalleryRepository
    {
        public EmployeeGalleryRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeGallery>> GetAllByEmployeeIdAsync(bool isTrackChanges, Guid employeeId)
        {
            return await FindByCondition(isTrackChanges, e => e.EmployeeId == employeeId).ToListAsync();
        }
    }
}
