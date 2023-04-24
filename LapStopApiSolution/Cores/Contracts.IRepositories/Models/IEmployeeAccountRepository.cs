using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeAccountRepository
    {
        List<EmployeeAccount> GetAll(bool isTrackChanges);
        EmployeeAccount? GetByEmployeeId(bool isTrackChanges, Guid employeeId);
    }
}
