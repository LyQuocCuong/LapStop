using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductGalleryRepository
    {
        IEnumerable<ProductGallery> GetAllByProductId(bool isTrackChanges, Guid productId);
    }
}
