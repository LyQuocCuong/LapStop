using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IEmployeeGalleryService
    {
        IEnumerable<EmployeeGalleryDto> GetAllByEmployeeId(Guid employeeId);
    }
}
