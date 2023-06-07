namespace Repositories.Models
{
    internal sealed class ImportedInvoiceDetailRepository : RepositoryBase<ImportedInvoiceDetail>, IImportedInvoiceDetailRepository
    {
        public ImportedInvoiceDetailRepository(LapStopContext context) : base(context)
        {
        }
    }
}
