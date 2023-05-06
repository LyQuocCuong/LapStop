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

        public IEnumerable<Product> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public Product? GetOneById(bool isTrackChanges, Guid productId)
        {
            return FindByCondition(isTrackChanges, e => e.Id == productId).FirstOrDefault();
        }

        public bool IsValidId(Guid productId)
        {
            return FindByCondition(isTrackChanges: false, e => e.Id == productId).Any();
        }
    }
}
