using Contracts.IRepositories.Identities;

namespace Contracts.IRepositories.Managers
{
    public interface IIdentityRepositoryManager
    {
        IIdentEmployeeRepository IdentEmployee { get; }

        IIdentRoleRepository IdentRole { get; }
    }
}
