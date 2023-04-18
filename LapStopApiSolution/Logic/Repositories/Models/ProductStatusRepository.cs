using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class ProductStatusRepository : RepositoryBase<ProductStatus>, IProductStatusRepository
    {
        public ProductStatusRepository(LapStopContext context) : base(context)
        {
        }

        public IEnumerable<ProductStatus> GetAll()
        {
            return new List<ProductStatus>()
            {
                new ProductStatus()
                {
                    Id = Guid.NewGuid(),
                    Name = "ABC",
                    Description = "Description",
                    IsEnable = true,
                    IsRemoved = true,
                }
            };
        }
    }
}
