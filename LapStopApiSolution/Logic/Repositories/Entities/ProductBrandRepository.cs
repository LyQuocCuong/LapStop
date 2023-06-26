using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class ProductBrandRepository : AbstractRepository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(LapStopContext context) : base(context)
        {
        }
    }
}
