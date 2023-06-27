namespace Repositories.Entities
{
    internal sealed class EmployeeAccountRepository : AbstractEntityRepository<EmployeeAccount>, IEmployeeAccountRepository
    {
        public EmployeeAccountRepository(EntityRepositoryParams repoParams) : base(repoParams)
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
