using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(LapStopContext context) : base(context)
        {
        }
    }
}
