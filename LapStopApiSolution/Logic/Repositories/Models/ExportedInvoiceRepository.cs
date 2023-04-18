using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class ExportedInvoiceRepository : RepositoryBase<ExportedInvoice>, IExportedInvoiceRepository
    {
        public ExportedInvoiceRepository(LapStopContext context) : base(context)
        {
        }
    }
}
