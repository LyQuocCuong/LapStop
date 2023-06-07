namespace Contracts.IRepositories.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(bool isTrackChanges, EmployeeRequestParam parameter);

        Task<int> CountAllAsync(EmployeeRequestParam parameter);

        Task<Employee?> GetOneByIdAsync(bool isTrackChanges, Guid employeeId);

        Task<bool> IsValidIdAsync(Guid employeeId);

        void Create(Employee employee);

        void Delete(Employee employee);
    }
}
