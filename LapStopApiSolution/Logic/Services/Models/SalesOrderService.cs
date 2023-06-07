namespace Services.Models
{
    internal sealed class SalesOrderService : ServiceBase, ISalesOrderService
    {
        public SalesOrderService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }
    }
}
