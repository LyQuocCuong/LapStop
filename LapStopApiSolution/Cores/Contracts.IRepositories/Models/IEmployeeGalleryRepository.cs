using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeGalleryRepository
    {
        IEnumerable<EmployeeGallery> GetAllByEmployeeId(bool isTrackChanges, Guid employeeId);
    }
}
