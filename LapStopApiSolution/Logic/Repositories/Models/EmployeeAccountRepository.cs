using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class EmployeeAccountRepository : RepositoryBase<EmployeeAccount>, IEmployeeAccountRepository
    {
        public EmployeeAccountRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeAccount>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<EmployeeAccount?> GetOneByEmployeeIdAsync(bool isTrackChanges, Guid employeeId)
        {
            return await FindByCondition(isTrackChanges, e => e.EmployeeId == employeeId).FirstOrDefaultAsync();
        }
    }
}
