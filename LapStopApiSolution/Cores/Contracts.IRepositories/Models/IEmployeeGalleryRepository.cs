using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeGalleryRepository
    {
        List<EmployeeGallery> GetByEmployeeId(bool isTrackChanges, Guid employeeId);
    }
}
