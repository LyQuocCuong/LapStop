namespace Repositories.Entities
{
    internal sealed class ProductBrandRepository : AbstractEntityRepository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
        {
        }
    }
}
