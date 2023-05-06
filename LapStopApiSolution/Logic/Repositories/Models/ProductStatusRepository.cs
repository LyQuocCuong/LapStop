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

        public IEnumerable<ProductStatus> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public ProductStatus? GetOneById(bool isTrackChanges, Guid productStatusId)
        {
            return FindByCondition(isTrackChanges, p =>  p.Id == productStatusId).FirstOrDefault();
        }
    }
}
