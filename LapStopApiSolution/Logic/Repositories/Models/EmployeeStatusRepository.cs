using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class EmployeeStatusRepository : RepositoryBase<EmployeeStatus>, IEmployeeStatusRepository
    {
        public EmployeeStatusRepository(LapStopContext context) : base(context)
        {
        }

        public IEnumerable<EmployeeStatus> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public EmployeeStatus? GetOneById(bool isTrackChanges, Guid employeeStatusId)
        {
            return FindByCondition(isTrackChanges, e => e.Id == employeeStatusId).FirstOrDefault();
        }
    }
}
