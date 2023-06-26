using Contracts.IServices.Managers;

namespace Contracts.IServices
{
    public interface IDomainServices
    {
        IEntityServiceManager EntityServices { get; }

        IIdentityServiceManager IdentityServices { get; }
    }
}
