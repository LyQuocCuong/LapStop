using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetAllByCartIdAsync(bool isTrackChanges, Guid cartId);
    }
}
