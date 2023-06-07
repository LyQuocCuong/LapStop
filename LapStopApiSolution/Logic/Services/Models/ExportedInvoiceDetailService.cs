namespace Services.Models
{
    internal sealed class ExportedInvoiceDetailService : ServiceBase, IExportedInvoiceDetailService
    {
        public ExportedInvoiceDetailService(ILogService logService,
                                               IMappingService mappingService,
                                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }
    }
}
