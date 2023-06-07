namespace Repositories.Models
{
    internal sealed class CartItemRepository : RepositoryBase<CartItem>, ICartItemRepository
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
