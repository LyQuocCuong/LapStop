using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductGalleryService
    {
        List<ProductGalleryDto> GetByProductId(bool isTrackChanges, Guid id);
    }
}
