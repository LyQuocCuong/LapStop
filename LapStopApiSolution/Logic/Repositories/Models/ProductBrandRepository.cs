namespace Repositories.Models
{
    internal sealed class ProductBrandRepository : RepositoryBase<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(LapStopContext context) : base(context)
        {
        }
    }
}
