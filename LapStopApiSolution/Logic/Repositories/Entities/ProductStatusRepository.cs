namespace Repositories.Entities
{
    internal sealed class ProductStatusRepository : AbstractEntityRepository<ProductStatus>, IProductStatusRepository
    {
        public ProductStatusRepository(LapStopContext context, IDomainRepositories domainRepositories) : base(context, domainRepositories)
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
