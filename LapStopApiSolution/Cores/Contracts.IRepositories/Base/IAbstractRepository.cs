using Contracts.IRepositories.Managers;

namespace Contracts.IRepositories.Base
{
    public interface IAbstractRepository
    {
        #region Due to need to call Each Other (Repo call other Repos)

        IEntityRepositoryManager EntityRepositories { get; }

        IIdentityRepositoryManager IdentityRepositories { get; }

        #endregion
    }
}
