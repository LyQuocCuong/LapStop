namespace Repositories.Entities
{
    internal sealed class EmployeeStatusRepository : AbstractEntityRepository<EmployeeStatus>, IEmployeeStatusRepository
    {
        public EmployeeStatusRepository(EntityRepositoryParams repoParams) : base(repoParams)
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
