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

        public IEnumerable<EmployeeRole> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public EmployeeRole? GetOneById(bool isTrackChanges, Guid employeeRoleId)
        {
            return FindByCondition(isTrackChanges, e => e.Id == employeeRoleId).FirstOrDefault();
        }
    }
}
