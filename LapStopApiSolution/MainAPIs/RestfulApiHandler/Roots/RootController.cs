namespace RestfulApiHandler.Roots
{
    public abstract class RootController : ControllerBase
    {
        protected readonly ILogService _logService;
        protected readonly IServiceManager _serviceManager;

        public RootController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }
    }
}
