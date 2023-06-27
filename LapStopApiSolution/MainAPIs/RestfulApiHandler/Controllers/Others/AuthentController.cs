using Contracts.Utilities.Authentication;
using Domains.Identities;
using DTO.Input.FromBody.Authentication;

namespace RestfulApiHandler.Controllers.Others
{
    [ApiController]
    [Route("api/authenticate")]
    public sealed class AuthentController : AbstractController
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
            return Ok(new { Token = await _authentService.CreateToken(authentDto.Username) });
        }
    }
}
