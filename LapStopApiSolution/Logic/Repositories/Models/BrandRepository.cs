using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(LapStopContext context) : base(context)
        {
        }
    }
}
