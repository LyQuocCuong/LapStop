namespace Services.Models
{
    internal sealed class ImportedInvoiceDetailService : ServiceBase, IImportedInvoiceDetailService
    {
        public ImportedInvoiceDetailService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }
    }
}
