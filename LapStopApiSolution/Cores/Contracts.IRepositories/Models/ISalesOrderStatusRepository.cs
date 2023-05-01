using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ISalesOrderStatusRepository
    {
        List<SalesOrderStatus> GetAll(bool isTrackChanges);

        SalesOrderStatus? GetOneById(bool isTrackChanges, Guid salesOrderStatusId);
    }
}
