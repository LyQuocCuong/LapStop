namespace Contracts.IServices.Entities
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItemDto>> GetAllByCartIdAsync(Guid cartId);
    }
}
