using Contracts.Utilities.Authentication;
using DTO.Output.Token;

namespace RestfulApiHandler.Controllers.Authent
{
    [ApiController]
    [Route("api/token")]
    public sealed class TokenController : ControllerBase
    {
        private readonly IAuthentService _authentService;
        public TokenController(IAuthentService authentService)
        {
            _authentService = authentService;
        }
        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokensDto tokenDto)
        {
            var tokenDtoToReturn = await _authentService.ProcessExpiredAccessToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }


    }
}
