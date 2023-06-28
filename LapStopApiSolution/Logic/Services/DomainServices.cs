using Contracts.IServices.Managers;
using Services.Managers;

namespace Services
{
    public sealed class DomainServices : IDomainServices
    {
        private readonly Lazy<IEntityServiceManager> _entityServices;

        private readonly Lazy<IIdentityServiceManager> _identityServices;

        public DomainServices(IDomainRepositories domainRepositories,
                                UtilityServiceManager utilityServices)
        {
            // [ISSUE]: Due to Circular Dependency Error (with [IDomainServices])
            // ==> Can NOT register DI for entire [ServiceParams] class
            // [SOLUTION]: register DI for all PARAMETERS of [ServiceParams]
            // [SOLUTION]: using "this" for [IDomainService] instance.
            ServiceParams serviceParams = new ServiceParams(domainRepositories, this, utilityServices);

            _entityServices = new Lazy<IEntityServiceManager>(() => 
                                        new EntityServiceManager(serviceParams));

            _identityServices = new Lazy<IIdentityServiceManager>(() => 
                                        new IdentityServiceManager(serviceParams));
        }

        public IEntityServiceManager EntityServices => _entityServices.Value;

        public IIdentityServiceManager IdentityServices => _identityServices.Value;
    }
}
