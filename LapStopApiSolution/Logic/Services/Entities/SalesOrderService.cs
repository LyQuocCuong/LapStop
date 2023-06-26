namespace Services.Entities
{
    internal sealed class SalesOrderService : AbstractService, ISalesOrderService
    {
        public SalesOrderService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }
    }
}
