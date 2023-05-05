using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductGalleryService
    {
        List<ProductGalleryDto> GetAllByProductId(Guid productId);
    }
}
