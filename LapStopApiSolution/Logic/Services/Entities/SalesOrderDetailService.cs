namespace Services.Entities
{
    internal sealed class SalesOrderDetailService : AbstractService, ISalesOrderDetailService
    {
        public SalesOrderDetailService(IDomainRepositories domainRepository,
                                        IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }
    }
}
