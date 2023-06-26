using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class SalesOrderRepository : AbstractRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(LapStopContext context) : base(context)
        {
        }
    }
}
