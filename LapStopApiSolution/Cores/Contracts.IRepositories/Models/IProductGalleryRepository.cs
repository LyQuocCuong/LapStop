using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductGalleryRepository
    {
        List<ProductGallery> GetAllByProductId(bool isTrackChanges, Guid productId);
    }
}
