namespace Services.Models
{
    internal sealed class SalesOrderDetailService : ServiceBase, ISalesOrderDetailService
    {
        public SalesOrderDetailService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }
    }
}
