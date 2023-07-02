using Contracts.IServices.Managers;
using Contracts.Utilities.Logger;

namespace RestfulApiHandler.Base
{
    [ApiController]
    [ApiVersion("2.0", Deprecated = true)]
    [ApiExplorerSettings(GroupName = "v2")]
    public abstract class AbstractApiControllerVer02 : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IDomainServices _domainServices;

        public AbstractApiControllerVer02(ILogService logService, IDomainServices domainServices)
        {
            _logService = logService;
            _domainServices = domainServices;
        }

        public IEntityServiceManager EntityServices => _domainServices.EntityServices;

        public IIdentityServiceManager IdentityServices => _domainServices.IdentityServices;

        public ILogService LogService => _logService;

    }
}
