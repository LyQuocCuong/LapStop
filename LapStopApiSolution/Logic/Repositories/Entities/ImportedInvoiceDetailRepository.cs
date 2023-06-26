using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class ImportedInvoiceDetailRepository : AbstractRepository<ImportedInvoiceDetail>, IImportedInvoiceDetailRepository
    {
        public ImportedInvoiceDetailRepository(LapStopContext context) : base(context)
        {
        }
    }
}
