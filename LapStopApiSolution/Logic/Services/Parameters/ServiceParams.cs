namespace Services.Parameters
{
    public sealed class ServiceParams
    {
        public ServiceParams(IDomainRepositories domainRepositories,
                             IDomainServices domainServices,
                             UtilityServiceManager utilityServices) 
        {
            DomainRepositories = domainRepositories;
            DomainServices = domainServices;
            UtilityServices = utilityServices;
        }

        public readonly IDomainRepositories DomainRepositories;

        public readonly UtilityServiceManager UtilityServices;

        public readonly IDomainServices DomainServices;
    }
}
