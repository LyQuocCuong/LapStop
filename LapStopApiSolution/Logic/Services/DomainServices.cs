using Contracts.IServices.Managers;
using Services.Managers;

namespace Services
{
    public sealed class DomainServices : IDomainServices
    {
        private readonly Lazy<IEntityServiceManager> _entityServices;

        private readonly Lazy<IIdentityServiceManager> _identityServices;

        public DomainServices(IDomainRepositories domainRepositories,
                             IUtilityServices utilityServices)
        {
            _entityServices = new Lazy<IEntityServiceManager>(() => 
                                        new EntityServiceManager(domainRepositories, utilityServices));

            _identityServices = new Lazy<IIdentityServiceManager>(() => 
                                        new IdentityServiceManager(domainRepositories, utilityServices));
        }

        public IEntityServiceManager EntityServices => _entityServices.Value;

        public IIdentityServiceManager IdentityServices => _identityServices.Value;
    }
}
