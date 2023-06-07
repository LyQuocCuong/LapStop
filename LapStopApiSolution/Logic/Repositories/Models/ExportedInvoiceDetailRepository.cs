namespace Repositories.Models
{
    internal sealed class ExportedInvoiceDetailRepository : RepositoryBase<ExportedInvoiceDetail>, IExportedInvoiceDetailRepository
    {
        public ExportedInvoiceDetailRepository(LapStopContext context) : base(context)
        {
        }
    }
}
