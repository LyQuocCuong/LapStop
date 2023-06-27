namespace Repositories.Entities
{
    internal sealed class ProductGalleryRepository : AbstractEntityRepository<ProductGallery>, IProductGalleryRepository
    {
        public ProductGalleryRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }

        public async Task<IEnumerable<ProductGallery>> GetAllByProductIdAsync(bool isTrackChanges, Guid productId)
        {
            return await FindByCondition(isTrackChanges, e => e.ProductId == productId).ToListAsync();
        }
    }
}
