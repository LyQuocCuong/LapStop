namespace Repositories.Entities
{
    internal sealed class SalesOrderRepository : AbstractEntityRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }
    }
}
