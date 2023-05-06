using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeStatusRepository
    {
        IEnumerable<EmployeeStatus> GetAll(bool isTrackChanges);

        EmployeeStatus? GetOneById(bool isTrackChanges, Guid employeeStatusId);
    }
}
