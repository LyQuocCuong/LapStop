using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class ProductGalleryRepository : AbstractRepository<ProductGallery>, IProductGalleryRepository
    {
        public ProductGalleryRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductGallery>> GetAllByProductIdAsync(bool isTrackChanges, Guid productId)
        {
            return await FindByCondition(isTrackChanges, e => e.ProductId == productId).ToListAsync();
        }
    }
}
