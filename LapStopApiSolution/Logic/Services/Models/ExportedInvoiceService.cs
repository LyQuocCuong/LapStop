using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class ExportedInvoiceService : ServiceBase, IExportedInvoiceService
    {
        public ExportedInvoiceService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
