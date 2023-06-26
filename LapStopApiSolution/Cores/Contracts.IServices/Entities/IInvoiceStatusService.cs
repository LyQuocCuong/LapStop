namespace Contracts.IServices.Entities
{
    public interface IInvoiceStatusService
    {
        Task<IEnumerable<InvoiceStatusDto>> GetAllAsync();

        Task<InvoiceStatusDto?> GetOneByIdAsync(Guid invoiceStatusId);
    }
}
