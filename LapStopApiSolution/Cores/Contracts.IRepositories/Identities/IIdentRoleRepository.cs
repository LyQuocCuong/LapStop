namespace Contracts.IRepositories.Identities
{
    public interface IIdentRoleRepository
    {
        Task<bool> IsRoleExistsAsync(string roleName);
    }
}
