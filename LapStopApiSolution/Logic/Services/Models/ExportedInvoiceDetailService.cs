using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class ExportedInvoiceDetailService : ServiceBase, IExportedInvoiceDetailService
    {
        public ExportedInvoiceDetailService(IRepositoryManager repositoryManager) : base(repositoryManager)
        {
        }
    }
}
