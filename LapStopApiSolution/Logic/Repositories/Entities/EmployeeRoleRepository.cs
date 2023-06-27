namespace Repositories.Entities
{
    internal sealed class EmployeeRoleRepository : AbstractEntityRepository<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(EntityRepositoryParams repoParams) : base(repoParams)
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
