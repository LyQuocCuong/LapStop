namespace Repositories.Entities
{
    internal sealed class SalesOrderStatusRepository : AbstractEntityRepository<SalesOrderStatus>, ISalesOrderStatusRepository
    {
        public SalesOrderStatusRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }

        public async Task<IEnumerable<SalesOrderStatus>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<SalesOrderStatus?> GetOneByIdAsync(bool isTrackChanges, Guid salesOrderStatusId)
        {
            return await FindByCondition(isTrackChanges, s => s.Id == salesOrderStatusId).FirstOrDefaultAsync();
        }
    }
}
