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

        public List<EmployeeStatus> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public EmployeeStatus? GetById(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, e => e.Id == id).FirstOrDefault();
        }
    }
}
