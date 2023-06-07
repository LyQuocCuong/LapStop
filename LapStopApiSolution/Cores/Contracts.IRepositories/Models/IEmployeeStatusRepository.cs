namespace Contracts.IRepositories.Models
{
    public interface IEmployeeStatusRepository
    {
        Task<IEnumerable<EmployeeStatus>> GetAllAsync(bool isTrackChanges);

        Task<EmployeeStatus?> GetOneByIdAsync(bool isTrackChanges, Guid employeeStatusId);
    }
}
