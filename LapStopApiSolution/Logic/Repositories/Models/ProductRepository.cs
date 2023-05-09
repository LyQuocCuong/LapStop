using Contracts.IRepositories.Models;
using Domains.Models;
using DTO.Input.FromQuery.Parameters;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(LapStopContext context) : base(context)
        {
        }
                
        public async Task<IEnumerable<Product>> GetAllAsync(bool isTrackChanges, ProductParameters parameters)
        {
            return await FindAll(isTrackChanges)
                            .OrderBy(p => p.Name)
                            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                            .Take(parameters.PageSize)
                            .ToListAsync();
        }

        public async Task<Product?> GetOneByIdAsync(bool isTrackChanges, Guid productId)
        {
            return await FindByCondition(isTrackChanges, e => e.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidIdAsync(Guid productId)
        {
            return await FindByCondition(isTrackChanges: false, e => e.Id == productId).AnyAsync();
        }

        public void Create(Product product)
        {
            base.CreateModel(product);
        }

        public void Delete(Product product)
        {
            base.DeleteModel(product);
        }
    }
}
