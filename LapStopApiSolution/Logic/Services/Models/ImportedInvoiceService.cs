using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;

namespace Services.Models
{
    internal sealed class ImportedInvoiceService : ServiceBase, IImportedInvoiceService
    {
        public ImportedInvoiceService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }
    }
}
