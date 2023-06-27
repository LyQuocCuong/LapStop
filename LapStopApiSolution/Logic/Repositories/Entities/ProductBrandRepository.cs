namespace Repositories.Entities
{
    internal sealed class ProductBrandRepository : AbstractEntityRepository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }
    }
}
