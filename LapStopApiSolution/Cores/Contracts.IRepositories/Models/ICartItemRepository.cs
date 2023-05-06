using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICartItemRepository
    {
        IEnumerable<CartItem> GetAllByCartId(bool isTrackChanges, Guid cartId);
    }
}
