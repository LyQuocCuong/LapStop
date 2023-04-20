using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IInvoiceStatusService
    {
        List<InvoiceStatusDto> GetAll(bool isTrackChanges);
        InvoiceStatusDto? GetById(bool isTrackChanges, Guid id);
    }
}
