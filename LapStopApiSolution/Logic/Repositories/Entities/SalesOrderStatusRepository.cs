using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class SalesOrderStatusRepository : AbstractRepository<SalesOrderStatus>, ISalesOrderStatusRepository
    {
        public SalesOrderStatusRepository(LapStopContext context) : base(context)
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
