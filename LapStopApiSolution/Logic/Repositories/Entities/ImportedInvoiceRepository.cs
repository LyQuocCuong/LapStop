using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class ImportedInvoiceRepository : AbstractRepository<ImportedInvoice>, IImportedInvoiceRepository
    {
        public ImportedInvoiceRepository(LapStopContext context) : base(context)
        {
        }
    }
}
