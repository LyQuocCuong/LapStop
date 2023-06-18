namespace Contracts.Authentication
{
    public interface IAuthentService
    {
        Task<string> CreateToken(string username);
    }
}
