using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductRepository
    {
        List<Product> GetAll(bool isTrackChanges);
        Product? GetById(bool isTrackChanges, Guid id);
        bool IsValidProductId(Guid id);
    }
}
