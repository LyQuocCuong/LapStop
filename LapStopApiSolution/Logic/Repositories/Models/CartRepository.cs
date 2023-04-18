using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(LapStopContext context) : base(context)
        {
        }
    }
}
