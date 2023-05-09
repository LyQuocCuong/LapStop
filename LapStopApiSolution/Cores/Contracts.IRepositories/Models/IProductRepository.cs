using Domains.Models;
using DTO.Input.FromQuery.Parameters;

namespace Contracts.IRepositories.Models
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(bool isTrackChanges, ProductParameters parameters);

        Task<Product?> GetOneByIdAsync(bool isTrackChanges, Guid productId);

        Task<bool> IsValidIdAsync(Guid productId);

        void Create(Product product);

        void Delete(Product product);
    }
}
