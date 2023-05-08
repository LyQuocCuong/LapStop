using DTO.Output.Data;

namespace Contracts.IServices.Models
{
    public interface IProductGalleryService
    {
        Task<IEnumerable<ProductGalleryDto>> GetAllByProductIdAsync(Guid productId);
    }
}
