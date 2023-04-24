using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductService
    {
        List<ProductDto> GetAll(bool isTrackChanges);
        ProductDto? GetById(bool isTrackChanges, Guid id);
        bool IsValidProductId(Guid id);
    }
}
