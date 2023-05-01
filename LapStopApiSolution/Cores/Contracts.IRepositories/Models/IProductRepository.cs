using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductRepository
    {
        List<Product> GetAll(bool isTrackChanges);

        Product? GetOneById(bool isTrackChanges, Guid productId);

        bool IsValidId(Guid productId);
    }
}
