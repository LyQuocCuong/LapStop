using DTO.Output;
using DTO.Parameters;

namespace Contracts.IServices.Models
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(ProductParameters parameters);

        Task<ProductDto?> GetOneByIdAsync(Guid productId);

        Task<bool> IsValidIdAsync(Guid productId);
    }
}
