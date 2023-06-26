namespace Services.Entities
{
    internal sealed class ProductBrandService : AbstractService, IProductBrandService
    {
        public ProductBrandService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }
    }
}
