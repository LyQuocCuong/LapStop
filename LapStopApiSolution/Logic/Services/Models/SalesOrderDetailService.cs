using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class SalesOrderDetailService : ServiceBase, ISalesOrderDetailService
    {
        public SalesOrderDetailService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
