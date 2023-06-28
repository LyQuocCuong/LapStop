using Contracts.IRepositories.Managers;
using Contracts.IServices.Managers;
using Contracts.Utilities;

namespace Contracts.IServices.Base
{
    public interface IAbstractService
    {
        IEntityRepositoryManager EntityRepositories { get; }

        IIdentityRepositoryManager IdentityRepositories { get; }

        #region Due to need to call Each Other (Services call other Services)

        IEntityServiceManager EntityServices { get; }

        IIdentityServiceManager IdentityServices { get; }

        #endregion

        UtilityServiceManager UtilityServices { get; }

        Task SaveChangesToDatabaseAsync();
    }
}
