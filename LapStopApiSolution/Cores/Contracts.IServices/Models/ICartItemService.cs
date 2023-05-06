using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICartItemService
    {
        IEnumerable<CartItemDto> GetAllByCartId(Guid cartId);
    }
}
