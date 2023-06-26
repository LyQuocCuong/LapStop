using Contracts.IServices.Identities;

namespace Contracts.IServices.Managers
{
    public interface IIdentityServiceManager
    {
        IIdentEmployeeService IdentEmployee { get; }
    }
}
