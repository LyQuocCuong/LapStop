using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class BrandService : ServiceBase, IBrandService
    {
        public BrandService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
