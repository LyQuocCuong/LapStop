using Domains.Models;
using DTO.Input.FromQuery.Parameters;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(bool isTrackChanges, EmployeeParameter parameter);

        Task<int> CountAllAsync(EmployeeParameter parameter);

        Task<Employee?> GetOneByIdAsync(bool isTrackChanges, Guid employeeId);

        Task<bool> IsValidIdAsync(Guid employeeId);

        void Create(Employee employee);

        void Delete(Employee employee);
    }
}
