namespace Repositories.Models
{
    internal sealed class ProductStatusRepository : RepositoryBase<ProductStatus>, IProductStatusRepository
    {
        public ProductStatusRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductStatus>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<ProductStatus?> GetOneByIdAsync(bool isTrackChanges, Guid productStatusId)
        {
            return await FindByCondition(isTrackChanges, p =>  p.Id == productStatusId).FirstOrDefaultAsync();
        }
    }
}
