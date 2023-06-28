using Contracts.IRepositories.Managers;
using Contracts.IServices.Base;
using Contracts.IServices.Managers;

namespace Services.Base
{
    internal abstract class AbstractService : IAbstractService
    {
        private readonly IDomainRepositories _domainRepositories;
        private readonly IDomainServices _domainServices;
        private readonly UtilityServiceManager _utilityServices;

        internal AbstractService(ServiceParams serviceParams)
        {
            _domainRepositories = serviceParams.DomainRepositories;
            _domainServices = serviceParams.DomainServices;
            _utilityServices = serviceParams.UtilityServices;
        }

        public IEntityRepositoryManager EntityRepositories 
            => _domainRepositories.EntityRepositories;

        public IIdentityRepositoryManager IdentityRepositories 
            => _domainRepositories.IdentityRepositories;

        public UtilityServiceManager UtilityServices => _utilityServices;

        #region Due to need to call Each Other (Services call other Services)

        public IEntityServiceManager EntityServices 
            => _domainServices.EntityServices;

        public IIdentityServiceManager IdentityServices
            => _domainServices.IdentityServices;

        #endregion

        public async Task SaveChangesToDatabaseAsync()
        {
            await _domainRepositories.SaveChangesToDatabaseAsync();
        }
    }
}
