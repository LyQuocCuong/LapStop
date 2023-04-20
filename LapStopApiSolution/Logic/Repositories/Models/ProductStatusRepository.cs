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

        public List<ProductStatus> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public ProductStatus? GetById(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, p =>  p.Id == id).FirstOrDefault();
        }
    }
}
