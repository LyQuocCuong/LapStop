namespace Contracts.IRepositories.Entities
{
    public interface ISalesOrderStatusRepository
    {
        Task<IEnumerable<SalesOrderStatus>> GetAllAsync(bool isTrackChanges);

        Task<SalesOrderStatus?> GetOneByIdAsync(bool isTrackChanges, Guid salesOrderStatusId);
    }
}
