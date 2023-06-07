namespace Repositories.Models
{
    internal sealed class SalesOrderDetailRepository : RepositoryBase<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(LapStopContext context) : base(context)
        {
        }
    }
}
