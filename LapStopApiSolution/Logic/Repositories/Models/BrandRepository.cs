using Contracts.IRepositories.Models;
using Domains.Models;
using DTO.Input.FromQuery.Parameters;
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

        public async Task<IEnumerable<Brand>> GetAllAsync(bool isTrackChanges, BrandParameters parameters)
        {
            return await FindAll(isTrackChanges)
                            .OrderBy(b => b.Name)
                            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                            .Take(parameters.PageSize)
                            .ToListAsync();
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
