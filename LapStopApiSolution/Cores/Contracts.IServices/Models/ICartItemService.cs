using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICartItemService
    {
        List<CartItemDto> GetAllByCartId(Guid cartId);
    }
}
