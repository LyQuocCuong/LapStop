namespace Contracts.IServices.Entities
{
    public interface IEmployeeGalleryService
    {
        Task<IEnumerable<EmployeeGalleryDto>> GetAllByEmployeeIdAsync(Guid employeeId);
    }
}
