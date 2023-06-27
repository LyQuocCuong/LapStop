namespace Repositories.Entities
{
    internal sealed class CartItemRepository : AbstractEntityRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(LapStopContext context,
                                IDomainRepositories domainRepositories)
            : base(context, domainRepositories)
        {
        }

        public async Task<IEnumerable<CartItem>> GetAllByCartIdAsync(bool isTrackChanges, Guid cartId)
        {
            return await FindByCondition(isTrackChanges, cartItem => cartItem.CartId == cartId).ToListAsync();
        }
    }
}
