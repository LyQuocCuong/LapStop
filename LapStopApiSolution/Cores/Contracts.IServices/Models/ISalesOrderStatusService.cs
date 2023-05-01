using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ISalesOrderStatusService
    {
        List<SalesOrderStatusDto> GetAll(bool isTrackChanges);

        SalesOrderStatusDto? GetOneById(bool isTrackChanges, Guid salesOrderStatusId);
    }
}
