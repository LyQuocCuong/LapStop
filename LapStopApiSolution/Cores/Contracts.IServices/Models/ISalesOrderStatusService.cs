using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ISalesOrderStatusService
    {
        List<SalesOrderStatusDto> GetAll();

        SalesOrderStatusDto? GetOneById(Guid salesOrderStatusId);
    }
}
