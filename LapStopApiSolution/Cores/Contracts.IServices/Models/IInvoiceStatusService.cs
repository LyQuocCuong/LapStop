using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IInvoiceStatusService
    {
        List<InvoiceStatusDto> GetAll();

        InvoiceStatusDto? GetOneById(Guid invoiceStatusId);
    }
}
