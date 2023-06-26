using Contracts.IServices.Managers;
using Services.Identities;

namespace Services.Managers
{
    public sealed class IdentityServiceManager : IIdentityServiceManager
    {
        private readonly Lazy<IIdentEmployeeService> _identEmployeeService;

        public IdentityServiceManager(IDomainRepositories domainRepositories,
                                      IUtilityServices utilityServices)
        {
            _identEmployeeService = new Lazy<IIdentEmployeeService>(() => new IdentEmployeeService(domainRepositories, utilityServices));
        }

        public IIdentEmployeeService IdentEmployee => _identEmployeeService.Value;
    }
}
