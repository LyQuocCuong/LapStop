using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeGalleryRepository
    {
        List<EmployeeGallery> GetAllByEmployeeId(bool isTrackChanges, Guid employeeId);
    }
}
