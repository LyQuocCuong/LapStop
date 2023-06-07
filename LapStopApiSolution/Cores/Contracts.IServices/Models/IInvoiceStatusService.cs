namespace Contracts.IServices.Models
{
    public interface IInvoiceStatusService
    {
        Task<IEnumerable<InvoiceStatusDto>> GetAllAsync();

        Task<InvoiceStatusDto?> GetOneByIdAsync(Guid invoiceStatusId);
    }
}
