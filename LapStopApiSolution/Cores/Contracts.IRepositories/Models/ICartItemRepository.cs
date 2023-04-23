using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICartItemRepository
    {
        List<CartItem> GetAll(bool isTrackChanges, Guid cartId);
    }
}
