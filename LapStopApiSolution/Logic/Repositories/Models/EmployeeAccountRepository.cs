using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class EmployeeAccountRepository : RepositoryBase<EmployeeAccount>, IEmployeeAccountRepository
    {
        public EmployeeAccountRepository(LapStopContext context) : base(context)
        {
        }

        public List<EmployeeAccount> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public EmployeeAccount? GetOneByEmployeeId(bool isTrackChanges, Guid employeeId)
        {
            return FindByCondition(isTrackChanges, e => e.EmployeeId == employeeId).FirstOrDefault();
        }
    }
}
