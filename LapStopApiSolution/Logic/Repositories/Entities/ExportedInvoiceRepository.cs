using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class ExportedInvoiceRepository : AbstractRepository<ExportedInvoice>, IExportedInvoiceRepository
    {
        public ExportedInvoiceRepository(LapStopContext context) : base(context)
        {
        }
    }
}
