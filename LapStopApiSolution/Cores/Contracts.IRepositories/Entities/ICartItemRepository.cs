namespace Contracts.IRepositories.Entities
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetAllByCartIdAsync(bool isTrackChanges, Guid cartId);
    }
}
