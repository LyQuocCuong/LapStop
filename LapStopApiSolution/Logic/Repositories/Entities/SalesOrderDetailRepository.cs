namespace Repositories.Entities
{
    internal sealed class SalesOrderDetailRepository : AbstractEntityRepository<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }
    }
}
