using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class SalesOrderDetailRepository : AbstractRepository<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(LapStopContext context) : base(context)
        {
        }
    }
}
