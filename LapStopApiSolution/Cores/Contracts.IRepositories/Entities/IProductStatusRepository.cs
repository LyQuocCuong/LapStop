namespace Contracts.IRepositories.Entities
{
    public interface IProductStatusRepository
    {
        Task<IEnumerable<ProductStatus>> GetAllAsync(bool isTrackChanges);

        Task<ProductStatus?> GetOneByIdAsync(bool isTrackChanges, Guid productStatusId);
    }
}
