using Contracts.IServices.Managers;
using Contracts.Utilities.Logger;

namespace RestfulApiHandler.Base
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api")]
    public abstract class AbstractApiControllerVer01 : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IDomainServices _domainServices;

        public AbstractApiControllerVer01(ILogService logService, IDomainServices domainServices)
        {
            _logService = logService;
            _domainServices = domainServices;
        }

        public IEntityServiceManager EntityServices => _domainServices.EntityServices;

        public IIdentityServiceManager IdentityServices => _domainServices.IdentityServices;

        public ILogService LogService => _logService;

    }
}
