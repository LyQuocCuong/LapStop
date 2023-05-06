using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeAccountRepository
    {
        Task<IEnumerable<EmployeeAccount>> GetAllAsync(bool isTrackChanges);

        Task<EmployeeAccount?> GetOneByEmployeeIdAsync(bool isTrackChanges, Guid employeeId);
    }
}
