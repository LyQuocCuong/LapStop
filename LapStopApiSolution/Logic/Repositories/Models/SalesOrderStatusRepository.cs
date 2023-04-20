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

        public List<SalesOrderStatus> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public SalesOrderStatus? GetById(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, s => s.Id == id).FirstOrDefault();
        }
    }
}
