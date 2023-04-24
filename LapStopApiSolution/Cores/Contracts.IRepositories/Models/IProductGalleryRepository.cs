using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductGalleryRepository
    {
        List<ProductGallery> GetByProductId(bool isTrackChanges, Guid id);
    }
}
