using Contracts.IRepositories.Managers;

namespace Contracts.IRepositories
{
    public interface IDomainRepositories
    {
        IEntityRepositoryManager EntityRepositories { get; }

        IIdentityRepositoryManager IdentityRepositories { get; }

        Task SaveChangesToDatabaseAsync();
    }
}
