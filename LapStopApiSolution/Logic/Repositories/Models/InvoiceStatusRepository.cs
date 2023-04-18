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
    }
}
