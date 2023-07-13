using Contracts.IRepositories;
using Contracts.IRepositories.Managers;
using Contracts.Utilities;

namespace Application.Handlers.Base
{
    public abstract class BaseRequestHandler
    {
        private readonly IDomainRepositories _domainRepositories;

        protected BaseRequestHandler(IDomainRepositories domainRepositories,
                              UtilityServiceManager utilityServices)
        {
            _domainRepositories = domainRepositories;
            EntityRepositories = domainRepositories.EntityRepositories;
            UtilityServices = utilityServices;
        }

        public IEntityRepositoryManager EntityRepositories { get; }
        public UtilityServiceManager UtilityServices { get; }

        public async Task SaveChanges()
        {
            await _domainRepositories.SaveChangesToDatabaseAsync();
        }

    }
}
