using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class EmployeeGalleryRepository : AbstractRepository<EmployeeGallery>, IEmployeeGalleryRepository
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
