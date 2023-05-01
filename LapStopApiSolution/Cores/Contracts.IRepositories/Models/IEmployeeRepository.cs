using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll(bool isTrackChanges);

        Employee? GetOneById(bool isTrackChanges, Guid employeeId);

        bool IsValidId(Guid employeeId);
    }
}
