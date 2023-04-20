using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ISalesOrderStatusRepository
    {
        List<SalesOrderStatus> GetAll(bool isTrackChanges);
        SalesOrderStatus? GetById(bool isTrackChanges, Guid id);
    }
}
