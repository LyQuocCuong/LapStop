using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IInvoiceStatusRepository
    {
        List<InvoiceStatus> GetAll(bool isTrackChanges);

        InvoiceStatus? GetOneById(bool isTrackChanges, Guid invoiceStatusId);
    }
}
