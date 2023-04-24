using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeGalleryService
    {
        List<EmployeeGalleryDto> GetByEmployeeId(bool isTrackChanges, Guid employeeId);
    }
}
