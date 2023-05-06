using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IInvoiceStatusService
    {
        IEnumerable<InvoiceStatusDto> GetAll();

        InvoiceStatusDto? GetOneById(Guid invoiceStatusId);
    }
}
