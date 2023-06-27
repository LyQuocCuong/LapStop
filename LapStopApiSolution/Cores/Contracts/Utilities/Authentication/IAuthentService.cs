using DTO.Output.Token;

namespace Contracts.Utilities.Authentication
{
    public interface IAuthentService
    {
        Task<TokensDto> GenerateTokens(string username);

        Task<TokensDto> ProcessExpiredAccessToken(TokensDto inputTokenDto);
    }
}
