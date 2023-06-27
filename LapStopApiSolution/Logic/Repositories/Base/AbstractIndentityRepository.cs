using Contracts.IRepositories.Base;
using Contracts.IRepositories.Managers;

namespace Repositories.Base
{
    internal abstract class AbstractIndentityRepository : IAbstractRepository
    {
        private readonly IDomainRepositories _domainRepositories;

        public AbstractIndentityRepository(IDomainRepositories domainRepositories) 
        {
            _domainRepositories = domainRepositories;
        }

        #region Due to need to call Each Other (Repo call other Repos)

        public IEntityRepositoryManager EntityRepositories => _domainRepositories.EntityRepositories;

        public IIdentityRepositoryManager IdentityRepositories => _domainRepositories.IdentityRepositories;

        #endregion
    }
}
