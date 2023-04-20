using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductStatusRepository
    {
        List<ProductStatus> GetAll(bool isTrackChanges);
        ProductStatus? GetById(bool isTrackChanges, Guid id);
    }
}
