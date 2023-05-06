using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductGalleryService
    {
        IEnumerable<ProductGalleryDto> GetAllByProductId(Guid productId);
    }
}
