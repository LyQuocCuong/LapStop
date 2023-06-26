namespace Contracts.Utilities.Authentication
{
    public interface IAuthentService<TIdentityUser>
    {
        Task<string> CreateToken(string username);
    }
}
