namespace Services.Entities
{
    internal sealed class CartService : AbstractService, ICartService
    {
        public CartService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            IEnumerable<Cart> carts = await EntityRepositories.Cart.GetAllAsync(isTrackChanges: false);
            return UtilServices.Mapper.ExecuteMapping<IEnumerable<Cart>, IEnumerable<CartDto>>(carts);
        }

        public async Task<CartDto?> GetOneByCustomerIdAsync(Guid customerId)
        {
            if (await EntityRepositories.Customer.IsValidIdAsync(customerId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(CartService), nameof(GetOneByCustomerIdAsync), typeof(Customer), customerId);
            }
            Cart? cart = await EntityRepositories.Cart.GetOneByCustomerIdAsync(isTrackChanges: false, customerId);
            if (cart == null)
            {
                throw new ExNotFoundInDBModel(nameof(CartService), nameof(GetOneByCustomerIdAsync), typeof(Cart), customerId);
            }
            return UtilServices.Mapper.ExecuteMapping<Cart, CartDto>(cart);
        }

        public async Task<bool> IsValidIdAsync(Guid cartId)
        {
            return await EntityRepositories.Cart.IsValidIdAsync(cartId);
        }
    }
}
