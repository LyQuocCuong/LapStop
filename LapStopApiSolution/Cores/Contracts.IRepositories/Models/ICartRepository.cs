using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICartRepository
    {
        List<Cart> GetAll(bool isTrackChanges);
        Cart? GetByCustomerId(bool isTrackChanges, Guid customerId);
        bool IsValidCartId(Guid cartId);
    }
}
