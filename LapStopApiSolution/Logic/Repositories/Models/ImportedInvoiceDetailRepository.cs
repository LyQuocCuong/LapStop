using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class ImportedInvoiceDetailRepository : RepositoryBase<ImportedInvoiceDetail>, IImportedInvoiceDetailRepository
    {
        public ImportedInvoiceDetailRepository(LapStopContext context) : base(context)
        {
        }
    }
}
