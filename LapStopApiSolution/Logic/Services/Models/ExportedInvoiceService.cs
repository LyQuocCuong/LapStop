namespace Services.Models
{
    internal sealed class ExportedInvoiceService : ServiceBase, IExportedInvoiceService
    {
        public ExportedInvoiceService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }
    }
}
