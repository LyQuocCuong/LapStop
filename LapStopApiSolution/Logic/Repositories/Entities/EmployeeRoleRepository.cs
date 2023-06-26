using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class EmployeeRoleRepository : AbstractRepository<EmployeeRole>, IEmployeeRoleRepository
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
