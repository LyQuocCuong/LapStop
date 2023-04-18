using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class ProductBrandService : ServiceBase, IProductBrandService
    {
        public ProductBrandService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
