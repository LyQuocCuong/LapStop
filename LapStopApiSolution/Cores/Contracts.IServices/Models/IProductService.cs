using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductService
    {
        List<ProductDto> GetAll();

        ProductDto? GetOneById(Guid productId);

        bool IsValidId(Guid productId);
    }
}
