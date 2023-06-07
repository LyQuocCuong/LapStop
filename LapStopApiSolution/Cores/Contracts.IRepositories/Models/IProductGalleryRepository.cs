namespace Contracts.IRepositories.Models
{
    public interface IProductGalleryRepository
    {
        Task<IEnumerable<ProductGallery>> GetAllByProductIdAsync(bool isTrackChanges, Guid productId);
    }
}
