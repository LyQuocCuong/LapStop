using Contracts.Utilities.Authentication;
using DTO.Output.Token;

namespace RestfulApiHandler.Controllers.Authentication
{
    [Route("api/token")]
    public sealed class TokenController : AbstractApiVer01Controller
    {
        private readonly IAuthentService _authentService;

        public TokenController(ILogService logService,
                                IDomainServices domainServices,
                                IAuthentService authentService)
            : base(logService, domainServices)
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
