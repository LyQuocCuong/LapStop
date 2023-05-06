using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductStatusRepository
    {
        IEnumerable<ProductStatus> GetAll(bool isTrackChanges);

        ProductStatus? GetOneById(bool isTrackChanges, Guid productStatusId);
    }
}
