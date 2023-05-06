using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ISalesOrderStatusRepository
    {
        Task<IEnumerable<SalesOrderStatus>> GetAllAsync(bool isTrackChanges);

        Task<SalesOrderStatus?> GetOneByIdAsync(bool isTrackChanges, Guid salesOrderStatusId);
    }
}
