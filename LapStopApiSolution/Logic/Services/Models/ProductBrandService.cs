namespace Services.Models
{
    internal sealed class ProductBrandService : ServiceBase, IProductBrandService
    {
        public ProductBrandService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }
    }
}
