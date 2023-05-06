using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IInvoiceStatusRepository
    {
        Task<IEnumerable<InvoiceStatus>> GetAllAsync(bool isTrackChanges);

        Task<InvoiceStatus?> GetOneByIdAsync(bool isTrackChanges, Guid invoiceStatusId);
    }
}
