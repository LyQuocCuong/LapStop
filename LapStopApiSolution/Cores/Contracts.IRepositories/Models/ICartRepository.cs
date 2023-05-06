using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICartRepository
    {
        IEnumerable<Cart> GetAll(bool isTrackChanges);

        Cart? GetOneByCustomerId(bool isTrackChanges, Guid customerId);

        bool IsValidId(Guid cartId);
    }
}
