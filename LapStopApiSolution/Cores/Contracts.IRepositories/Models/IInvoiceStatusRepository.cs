using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IInvoiceStatusRepository
    {
        IEnumerable<InvoiceStatus> GetAll(bool isTrackChanges);

        InvoiceStatus? GetOneById(bool isTrackChanges, Guid invoiceStatusId);
    }
}
