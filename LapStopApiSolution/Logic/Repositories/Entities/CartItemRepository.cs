using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class CartItemRepository : AbstractRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CartItem>> GetAllByCartIdAsync(bool isTrackChanges, Guid cartId)
        {
            return await FindByCondition(isTrackChanges, cartItem => cartItem.CartId == cartId).ToListAsync();
        }
    }
}
