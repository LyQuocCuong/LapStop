namespace Contracts.IRepositories.Entities
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllAsync(bool isTrackChanges, BrandRequestParam parameters);

        Task<int> CountAllAsync(BrandRequestParam parameters);

        Task<Brand?> GetOneByIdAsync(bool isTrackChanges, Guid brandId);

        Task<bool> IsValidIdAsync(Guid id);

        void Create(Brand brand);

        void Delete(Brand brand);
    }
}
