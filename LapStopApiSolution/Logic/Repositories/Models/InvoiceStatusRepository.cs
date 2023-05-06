using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class InvoiceStatusRepository : RepositoryBase<InvoiceStatus>, IInvoiceStatusRepository
    {
        public InvoiceStatusRepository(LapStopContext context) : base(context)
        {
        }

        public IEnumerable<InvoiceStatus> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public InvoiceStatus? GetOneById(bool isTrackChanges, Guid invoiceStatusId)
        {
            return FindByCondition(isTrackChanges, i => i.Id == invoiceStatusId).FirstOrDefault();
        }
    }
}
