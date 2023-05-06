using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(LapStopContext context) : base(context)
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
