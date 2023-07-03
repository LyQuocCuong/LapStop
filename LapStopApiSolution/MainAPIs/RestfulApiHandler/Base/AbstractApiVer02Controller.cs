using Contracts.IServices.Managers;

namespace RestfulApiHandler.Base
{
    [ApiController]
    [ApiVersion("2.0", Deprecated = true)]
    [ApiExplorerSettings(GroupName = "v2")]
    [Route("api/v2")]
    public abstract class AbstractApiVer02Controller : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IDomainServices _domainServices;

        public AbstractApiVer02Controller(ILogService logService, IDomainServices domainServices)
        {
            _logService = logService;
            _domainServices = domainServices;
        }

        public virtual IEntityServiceManager EntityServices => _domainServices.EntityServices;

        public virtual IIdentityServiceManager IdentityServices => _domainServices.IdentityServices;

        public virtual ILogService LogService => _logService;

    }
}
