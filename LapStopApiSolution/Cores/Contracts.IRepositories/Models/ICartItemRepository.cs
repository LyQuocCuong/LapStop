using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICartItemRepository
    {
        List<CartItem> GetByCartId(bool isTrackChanges, Guid cartId);
    }
}
