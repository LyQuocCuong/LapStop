using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeGalleryRepository
    {
        Task<IEnumerable<EmployeeGallery>> GetAllByEmployeeIdAsync(bool isTrackChanges, Guid employeeId);
    }
}
