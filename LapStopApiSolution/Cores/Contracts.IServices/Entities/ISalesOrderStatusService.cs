namespace Contracts.IServices.Entities
{
    public interface ISalesOrderStatusService
    {
        Task<IEnumerable<SalesOrderStatusDto>> GetAllAsync();

        Task<SalesOrderStatusDto?> GetOneByIdAsync(Guid salesOrderStatusId);
    }
}
