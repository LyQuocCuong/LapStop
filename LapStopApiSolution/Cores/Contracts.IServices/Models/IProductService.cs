using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto?> GetOneByIdAsync(Guid productId);

        Task<bool> IsValidIdAsync(Guid productId);
    }
}
