using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll(bool isTrackChanges);

        Product? GetOneById(bool isTrackChanges, Guid productId);

        bool IsValidId(Guid productId);
    }
}
