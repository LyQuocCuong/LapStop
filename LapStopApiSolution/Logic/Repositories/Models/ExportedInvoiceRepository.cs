namespace Repositories.Models
{
    internal sealed class ExportedInvoiceRepository : RepositoryBase<ExportedInvoice>, IExportedInvoiceRepository
    {
        public ExportedInvoiceRepository(LapStopContext context) : base(context)
        {
        }
    }
}
