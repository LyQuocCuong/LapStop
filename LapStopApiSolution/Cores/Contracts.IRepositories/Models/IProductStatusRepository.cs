using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IProductStatusRepository
    {
        IEnumerable<ProductStatus> GetAll();
    }
}
