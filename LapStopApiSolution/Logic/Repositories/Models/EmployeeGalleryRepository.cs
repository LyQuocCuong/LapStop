using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class EmployeeGalleryRepository : RepositoryBase<EmployeeGallery>, IEmployeeGalleryRepository
    {
        public EmployeeGalleryRepository(LapStopContext context) : base(context)
        {
        }

        public IEnumerable<EmployeeGallery> GetAllByEmployeeId(bool isTrackChanges, Guid employeeId)
        {
            return FindByCondition(isTrackChanges, e => e.EmployeeId == employeeId);
        }
    }
}
