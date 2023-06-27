namespace Repositories.Entities
{
    internal sealed class CartRepository : AbstractEntityRepository<Cart>, ICartRepository
    {
        public CartRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }

        public async Task<IEnumerable<Cart>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<Cart?> GetOneByCustomerIdAsync(bool isTrackChanges, Guid customerId)
        {
            return await FindByCondition(isTrackChanges, cart => cart.CustomerId == customerId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidIdAsync(Guid cartId)
        {
            return await FindByCondition(isTrackChanges: false, cart => cart.Id == cartId).AnyAsync();
        }
    }
}
