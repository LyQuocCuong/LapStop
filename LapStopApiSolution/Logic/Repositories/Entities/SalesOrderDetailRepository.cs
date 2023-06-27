namespace Repositories.Entities
{
    internal sealed class SalesOrderDetailRepository : AbstractEntityRepository<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }
    }
}
