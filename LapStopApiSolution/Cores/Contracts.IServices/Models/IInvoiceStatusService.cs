using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IInvoiceStatusService
    {
        List<InvoiceStatusDto> GetAll(bool isTrackChanges);

        InvoiceStatusDto? GetOneById(bool isTrackChanges, Guid invoiceStatusId);
    }
}
