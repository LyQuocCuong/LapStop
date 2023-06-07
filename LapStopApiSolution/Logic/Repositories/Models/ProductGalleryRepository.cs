namespace Repositories.Models
{
    internal sealed class ProductGalleryRepository : RepositoryBase<ProductGallery>, IProductGalleryRepository
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
