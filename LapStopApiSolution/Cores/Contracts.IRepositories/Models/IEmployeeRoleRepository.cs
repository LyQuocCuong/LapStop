namespace Contracts.IRepositories.Models
{
    public interface IEmployeeRoleRepository
    {
        Task<IEnumerable<EmployeeRole>> GetAllAsync(bool isTrackChanges);

        Task<EmployeeRole?> GetOneByIdAsync(bool isTrackChanges, Guid employeeRoleId);
    }
}
