using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class ImportedInvoiceService : ServiceBase, IImportedInvoiceService
    {
        public ImportedInvoiceService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
