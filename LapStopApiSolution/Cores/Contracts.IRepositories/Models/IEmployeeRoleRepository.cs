using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IEmployeeRoleRepository
    {
        List<EmployeeRole> GetAll(bool isTrackChanges);
    }
}
