using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class ExportedInvoiceDetailService : ServiceBase, IExportedInvoiceDetailService
    {
        public ExportedInvoiceDetailService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }
    }
}
