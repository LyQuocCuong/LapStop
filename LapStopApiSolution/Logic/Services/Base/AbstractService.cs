using Contracts.IRepositories.Managers;
using Contracts.IServices.Base;
using Contracts.Utilities;

namespace Services.Base
{
    internal abstract class AbstractService : IAbstractService
    {
        private readonly IDomainRepositories _domainRepositories;
        private readonly IUtilityServices _utilServices;

        internal AbstractService(IDomainRepositories domainRepository,
                                 IUtilityServices utilityServices)
        {
            _domainRepositories = domainRepository;
            _utilServices = utilityServices;
        }

        public IEntityRepositoryManager EntityRepositories => _domainRepositories.EntityRepositories;

        public IIdentityRepositoryManager IdentityRepositories => _domainRepositories.IdentityRepositories;

        public IUtilityServices UtilServices => _utilServices;

        public async Task SaveChangesToDatabaseAsync()
        {
            await _domainRepositories.SaveChangesAsync();
        }
    }
}
