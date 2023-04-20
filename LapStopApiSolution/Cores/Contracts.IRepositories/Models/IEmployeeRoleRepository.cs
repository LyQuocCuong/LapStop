using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeRoleRepository
    {
        List<EmployeeRole> GetAll(bool isTrackChanges);
        EmployeeRole? GetById(bool isTrackChanges, Guid id);
    }
}
