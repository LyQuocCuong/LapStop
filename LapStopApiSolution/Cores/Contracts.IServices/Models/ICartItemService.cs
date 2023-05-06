using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItemDto>> GetAllByCartIdAsync(Guid cartId);
    }
}
