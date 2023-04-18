using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class ImportedInvoiceRepository : RepositoryBase<ImportedInvoice>, IImportedInvoiceRepository
    {
        public ImportedInvoiceRepository(LapStopContext context) : base(context)
        {
        }
    }
}
