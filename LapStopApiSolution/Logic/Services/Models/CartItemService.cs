namespace Services.Models
{
    internal sealed class CartItemService : ServiceBase, ICartItemService
    {
        public CartItemService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<IEnumerable<CartItemDto>> GetAllByCartIdAsync(Guid cartId)
        {
            if (await _repositoryManager.Cart.IsValidIdAsync(cartId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(CartItemService), nameof(GetAllByCartIdAsync), typeof(Cart), cartId);
            }
            
            IEnumerable<CartItem> cartItems = await _repositoryManager.CartItem.GetAllByCartIdAsync(isTrackChanges: false, cartId);
            
            return _mappingService.Map<IEnumerable<CartItem>, IEnumerable<CartItemDto>>(cartItems);
        }
    }
}
