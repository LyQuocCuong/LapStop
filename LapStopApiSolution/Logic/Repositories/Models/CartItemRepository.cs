using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
    {
        public CartItemRepository(LapStopContext context) : base(context)
        {
        }

        public List<CartItem> GetByCartId(bool isTrackChanges, Guid cartId)
        {
            return FindByCondition(isTrackChanges, cartItem => cartItem.CartId == cartId).ToList();
        }
    }
}
