using Contracts.IServices.Managers;
using Contracts.Utilities.Logger;

namespace RestfulApiHandler.Base
{
    public abstract class AbstractController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IDomainServices _domainServices;

        public AbstractController(ILogService logService, IDomainServices domainServices)
        {
            _logService = logService;
            _domainServices = domainServices;
        }

        public IEntityServiceManager EntityServices => _domainServices.EntityServices;

        public IIdentityServiceManager IdentityServices => _domainServices.IdentityServices;

        public ILogService LogService => _logService;

    }
}
