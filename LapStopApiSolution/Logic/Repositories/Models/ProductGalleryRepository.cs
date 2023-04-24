using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class ProductGalleryRepository : RepositoryBase<ProductGallery>, IProductGalleryRepository
    {
        public ProductGalleryRepository(LapStopContext context) : base(context)
        {
        }

        public List<ProductGallery> GetByProductId(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, e => e.ProductId == id).ToList();
        }
    }
}
