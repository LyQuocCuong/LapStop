namespace Contracts.IRepositories.Entities
{
    public interface IEmployeeStatusRepository
    {
        Task<IEnumerable<EmployeeStatus>> GetAllAsync(bool isTrackChanges);

        Task<EmployeeStatus?> GetOneByIdAsync(bool isTrackChanges, Guid employeeStatusId);
    }
}
