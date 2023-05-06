using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ISalesOrderStatusService
    {
        IEnumerable<SalesOrderStatusDto> GetAll();

        SalesOrderStatusDto? GetOneById(Guid salesOrderStatusId);
    }
}
