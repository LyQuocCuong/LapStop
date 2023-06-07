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

        public async Task<IEnumerable<Brand>> GetAllAsync(bool isTrackChanges, BrandRequestParam parameters)
        {
            return await FindAll(isTrackChanges)
                            .OrderBy(b => b.Name)
                            //.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                            //.Take(parameters.PageSize)
                            .Page(parameters.PageNumber, parameters.PageSize)
                            .ToListAsync();
        }

        public async Task<int> CountAllAsync(BrandRequestParam parameters)
        {
            return await FindAll(isTrackChanges: false)
                            .CountAsync();
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
