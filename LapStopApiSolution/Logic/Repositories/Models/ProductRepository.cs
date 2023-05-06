using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<Product?> GetOneByIdAsync(bool isTrackChanges, Guid productId)
        {
            return await FindByCondition(isTrackChanges, e => e.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidIdAsync(Guid productId)
        {
            return await FindByCondition(isTrackChanges: false, e => e.Id == productId).AnyAsync();
        }
    }
}
