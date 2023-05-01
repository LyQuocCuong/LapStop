using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductService
    {
        List<ProductDto> GetAll(bool isTrackChanges);

        ProductDto? GetOneById(bool isTrackChanges, Guid productId);

        bool IsValidId(Guid productId);
    }
}
