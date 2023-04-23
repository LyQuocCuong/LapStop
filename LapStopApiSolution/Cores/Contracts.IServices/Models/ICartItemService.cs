using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICartItemService
    {
        List<CartItemDto> GetAll(bool isTrackChanges, Guid cartId);
    }
}
