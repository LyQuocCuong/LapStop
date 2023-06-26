using Contracts.IRepositories.Managers;
using Contracts.Utilities;

namespace Contracts.IServices.Base
{
    public interface IAbstractService
    {
        IEntityRepositoryManager EntityRepositories { get; }

        IIdentityRepositoryManager IdentityRepositories { get; }

        IUtilityServices UtilServices { get; }

        Task SaveChangesToDatabaseAsync();
    }
}
