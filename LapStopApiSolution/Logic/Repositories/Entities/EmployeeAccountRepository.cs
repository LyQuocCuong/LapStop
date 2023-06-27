namespace Repositories.Entities
{
    internal sealed class EmployeeAccountRepository : AbstractEntityRepository<EmployeeAccount>, IEmployeeAccountRepository
    {
        public EmployeeAccountRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
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
