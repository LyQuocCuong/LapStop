using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductStatusRepository
    {
        Task<IEnumerable<ProductStatus>> GetAllAsync(bool isTrackChanges);

        Task<ProductStatus?> GetOneByIdAsync(bool isTrackChanges, Guid productStatusId);
    }
}
