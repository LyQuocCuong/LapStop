using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class ImportedInvoiceDetailService : ServiceBase, IImportedInvoiceDetailService
    {
        public ImportedInvoiceDetailService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
