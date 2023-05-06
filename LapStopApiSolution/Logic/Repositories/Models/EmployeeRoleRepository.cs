using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class EmployeeRoleRepository : RepositoryBase<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EmployeeRole>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<EmployeeRole?> GetOneByIdAsync(bool isTrackChanges, Guid employeeRoleId)
        {
            return await FindByCondition(isTrackChanges, e => e.Id == employeeRoleId).FirstOrDefaultAsync();
        }
    }
}
