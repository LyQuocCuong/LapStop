using Contracts.IServices;

namespace Services
{
    internal abstract class ServiceBase : IServiceBase
    {
        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IMappingService _mappingService;
        protected readonly ILogService _logService;

        internal ServiceBase(ILogService logService,
                             IMappingService mappingService,
                             IRepositoryManager repositoryManager)
        {
            _logService = logService;
            _mappingService = mappingService;
            _repositoryManager = repositoryManager;
        }
    }
}
