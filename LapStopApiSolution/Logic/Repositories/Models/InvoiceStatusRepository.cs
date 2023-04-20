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

        public List<InvoiceStatus> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public InvoiceStatus? GetById(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, i => i.Id == id).FirstOrDefault();
        }
    }
}
