using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface IInvoiceStatusRepository
    {
        List<InvoiceStatus> GetAll(bool isTrackChanges);
        InvoiceStatus? GetById(bool isTrackChanges, Guid id);
    }
}
