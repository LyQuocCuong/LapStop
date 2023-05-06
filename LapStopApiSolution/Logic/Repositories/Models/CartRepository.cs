using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(LapStopContext context) : base(context)
        {
        }

        public IEnumerable<Cart> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public Cart? GetOneByCustomerId(bool isTrackChanges, Guid customerId)
        {
            return FindByCondition(isTrackChanges, cart => cart.CustomerId == customerId).FirstOrDefault();
        }

        public bool IsValidId(Guid cartId)
        {
            return FindByCondition(isTrackChanges: false, cart => cart.Id == cartId).Any();
        }
    }
}
