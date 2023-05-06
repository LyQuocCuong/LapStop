using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class SalesOrderStatusRepository : RepositoryBase<SalesOrderStatus>, ISalesOrderStatusRepository
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
