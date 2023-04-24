using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll(bool isTrackChanges);
        Employee? GetById(bool isTrackChanges, Guid id);
        bool IsValidEmployeeId(Guid id);
    }
}
