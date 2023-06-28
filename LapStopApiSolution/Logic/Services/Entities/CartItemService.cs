namespace Services.Entities
{
    internal sealed class CartItemService : AbstractService, ICartItemService
    {
        public CartItemService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        public async Task<IEnumerable<CartItemDto>> GetAllByCartIdAsync(Guid cartId)
        {
            if (await EntityRepositories.Cart.IsValidIdAsync(cartId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(CartItemService), nameof(GetAllByCartIdAsync), typeof(Cart), cartId);
            }
            
            IEnumerable<CartItem> cartItems = await EntityRepositories.CartItem.GetAllByCartIdAsync(isTrackChanges: false, cartId);
            
            return UtilityServices.Mapper.ExecuteMapping<IEnumerable<CartItem>, IEnumerable<CartItemDto>>(cartItems);
        }
    }
}
