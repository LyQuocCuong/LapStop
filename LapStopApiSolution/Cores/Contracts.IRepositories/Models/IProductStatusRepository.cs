using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductStatusRepository
    {
        List<ProductStatus> GetAll(bool isTrackChanges);

        ProductStatus? GetOneById(bool isTrackChanges, Guid productStatusId);
    }
}
