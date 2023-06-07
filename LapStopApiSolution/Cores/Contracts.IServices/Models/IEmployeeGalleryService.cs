namespace Contracts.IServices.Models
{
    public interface IEmployeeGalleryService
    {
        Task<IEnumerable<EmployeeGalleryDto>> GetAllByEmployeeIdAsync(Guid employeeId);
    }
}
