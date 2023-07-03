using Contracts.Utilities.Authentication;
using DTO.Input.FromBody.Authentication;

namespace RestfulApiHandler.Controllers.Authentication
{
    [Route("api/authenticate")]
    public sealed class AuthentController : AbstractApiVer01Controller
    {
        private readonly IAuthentService _authentService;

        public AuthentController(ILogService logService,
                                IDomainServices domainServices,
                                IAuthentService authentService)
            : base(logService, domainServices)
        {
            _authentService = authentService;
        }

        [HttpPost("employee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AuthenticateEmployee([FromBody] AuthentDto authentDto)
        {
            if (!await IdentityServices.IdentEmployee.IsValidAuthentData(authentDto))
            {
                return Unauthorized();
            }
            return Ok(await _authentService.GenerateTokens(authentDto.Username));
        }
    }
}
