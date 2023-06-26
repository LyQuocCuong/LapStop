namespace Contracts.IServices.Entities
{
    public interface IProductGalleryService
    {
        Task<IEnumerable<ProductGalleryDto>> GetAllByProductIdAsync(Guid productId);
    }
}
