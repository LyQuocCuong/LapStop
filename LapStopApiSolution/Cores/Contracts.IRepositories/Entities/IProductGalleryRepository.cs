namespace Contracts.IRepositories.Entities
{
    public interface IProductGalleryRepository
    {
        Task<IEnumerable<ProductGallery>> GetAllByProductIdAsync(bool isTrackChanges, Guid productId);
    }
}
