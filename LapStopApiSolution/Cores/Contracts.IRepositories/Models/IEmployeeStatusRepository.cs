using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeStatusRepository
    {
        List<EmployeeStatus> GetAll(bool isTrackChanges);

        EmployeeStatus? GetOneById(bool isTrackChanges, Guid employeeStatusId);
    }
}
