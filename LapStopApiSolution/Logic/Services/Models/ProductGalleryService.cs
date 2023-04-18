using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class ProductGalleryService : ServiceBase, IProductGalleryService
    {
        public ProductGalleryService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
