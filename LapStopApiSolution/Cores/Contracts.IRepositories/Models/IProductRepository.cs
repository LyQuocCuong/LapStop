using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(bool isTrackChanges);

        Task<Product?> GetOneByIdAsync(bool isTrackChanges, Guid productId);

        Task<bool> IsValidIdAsync(Guid productId);
    }
}
