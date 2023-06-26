using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class ExportedInvoiceDetailRepository : AbstractRepository<ExportedInvoiceDetail>, IExportedInvoiceDetailRepository
    {
        public ExportedInvoiceDetailRepository(LapStopContext context) : base(context)
        {
        }
    }
}
