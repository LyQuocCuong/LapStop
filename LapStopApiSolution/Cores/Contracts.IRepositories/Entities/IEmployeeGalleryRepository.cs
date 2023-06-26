namespace Contracts.IRepositories.Entities
{
    public interface IEmployeeGalleryRepository
    {
        Task<IEnumerable<EmployeeGallery>> GetAllByEmployeeIdAsync(bool isTrackChanges, Guid employeeId);
    }
}
