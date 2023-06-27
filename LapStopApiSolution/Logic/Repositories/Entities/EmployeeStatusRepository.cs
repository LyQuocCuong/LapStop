namespace Repositories.Entities
{
    internal sealed class EmployeeStatusRepository : AbstractEntityRepository<EmployeeStatus>, IEmployeeStatusRepository
    {
        public EmployeeStatusRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }

        public async Task<IEnumerable<EmployeeStatus>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<EmployeeStatus?> GetOneByIdAsync(bool isTrackChanges, Guid employeeStatusId)
        {
            return await FindByCondition(isTrackChanges, e => e.Id == employeeStatusId).FirstOrDefaultAsync();
        }
    }
}
