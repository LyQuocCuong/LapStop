using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Models
{
    internal sealed class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(LapStopContext context) : base(context)
        {
        }

        public void Create(Brand brand)
        {
            base.CreateModel(brand);
        }

        public void Delete(Brand brand)
        {
            base.DeleteModel(brand);
        }

        public async Task<IEnumerable<Brand>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<Brand?> GetOneByIdAsync(bool isTrackChanges, Guid brandId)
        {
            return await FindByCondition(isTrackChanges, brand => brand.Id == brandId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidIdAsync(Guid brandId)
        {
            return await FindByCondition(isTrackChanges: false, b => b.Id == brandId).AnyAsync();
        }
    }
}
