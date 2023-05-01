using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICartItemRepository
    {
        List<CartItem> GetAllByCartId(bool isTrackChanges, Guid cartId);
    }
}
