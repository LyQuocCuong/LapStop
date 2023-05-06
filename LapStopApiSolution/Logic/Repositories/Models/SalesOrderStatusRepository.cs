using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class SalesOrderStatusRepository : RepositoryBase<SalesOrderStatus>, ISalesOrderStatusRepository
    {
        public SalesOrderStatusRepository(LapStopContext context) : base(context)
        {
        }

        public IEnumerable<SalesOrderStatus> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public SalesOrderStatus? GetOneById(bool isTrackChanges, Guid salesOrderStatusId)
        {
            return FindByCondition(isTrackChanges, s => s.Id == salesOrderStatusId).FirstOrDefault();
        }
    }
}
