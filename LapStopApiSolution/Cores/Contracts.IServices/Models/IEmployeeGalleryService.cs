using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeGalleryService
    {
        List<EmployeeGalleryDto> GetAllByEmployeeId(bool isTrackChanges, Guid employeeId);
    }
}
