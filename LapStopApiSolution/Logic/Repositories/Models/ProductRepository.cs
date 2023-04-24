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

        public List<Product> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public Product? GetById(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, e => e.Id == id).FirstOrDefault();
        }

        public bool IsValidProductId(Guid id)
        {
            return FindByCondition(isTrackChanges: false, e => e.Id == id).Any();
        }
    }
}
