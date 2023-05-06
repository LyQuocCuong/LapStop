using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ISalesOrderStatusService
    {
        Task<IEnumerable<SalesOrderStatusDto>> GetAllAsync();

        Task<SalesOrderStatusDto?> GetOneByIdAsync(Guid salesOrderStatusId);
    }
}
