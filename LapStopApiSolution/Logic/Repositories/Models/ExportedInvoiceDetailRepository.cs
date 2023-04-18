using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class ExportedInvoiceDetailRepository : RepositoryBase<ExportedInvoiceDetail>, IExportedInvoiceDetailRepository
    {
        public ExportedInvoiceDetailRepository(LapStopContext context) : base(context)
        {
        }
    }
}
