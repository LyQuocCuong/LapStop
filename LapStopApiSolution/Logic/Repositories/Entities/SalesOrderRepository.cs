namespace Repositories.Entities
{
    internal sealed class SalesOrderRepository : AbstractEntityRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }
    }
}
