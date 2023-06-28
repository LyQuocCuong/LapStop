using Contracts.IServices.Managers;
using Services.Identities;

namespace Services.Managers
{
    public sealed class IdentityServiceManager : IIdentityServiceManager
    {
        private readonly Lazy<IIdentEmployeeService> _identEmployeeService;

        public IdentityServiceManager(ServiceParams serviceParams)
        {
            _identEmployeeService = new Lazy<IIdentEmployeeService>(() => new IdentEmployeeService(serviceParams));
        }

        public IIdentEmployeeService IdentEmployee => _identEmployeeService.Value;
    }
}
