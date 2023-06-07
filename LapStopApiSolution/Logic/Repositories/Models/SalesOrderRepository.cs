namespace Repositories.Models
{
    internal sealed class SalesOrderRepository : RepositoryBase<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(LapStopContext context) : base(context)
        {
        }
    }
}
