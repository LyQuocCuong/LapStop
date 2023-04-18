using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class SalesOrderService : ServiceBase, ISalesOrderService
    {
        public SalesOrderService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
