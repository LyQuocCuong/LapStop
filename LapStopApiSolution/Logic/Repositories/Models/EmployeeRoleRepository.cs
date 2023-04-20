using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class EmployeeRoleRepository : RepositoryBase<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(LapStopContext context) : base(context)
        {
        }

        public List<EmployeeRole> GetAll(bool isTrackChanges)
        {
            List<EmployeeRole> employeeRoles = FindAll(isTrackChanges).ToList();
            return employeeRoles;
        }
    }
}
