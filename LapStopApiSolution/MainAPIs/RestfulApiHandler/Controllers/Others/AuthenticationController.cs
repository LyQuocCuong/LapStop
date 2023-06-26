using Contracts.Utilities.Authentication;
using Domains.Identities;
using DTO.Input.FromBody.Authentication;

namespace RestfulApiHandler.Controllers.Others
{
    [ApiController]
    [Route("api/authenticate")]
    public sealed class AuthenticationController : AbstractController
    {
        private readonly IAuthentService<IdentEmployee> _authentEmployeeService;

        public AuthenticationController(ILogService logService,
                                        IDomainServices domainServices,
                                        IAuthentService<IdentEmployee> authentEmployeeService)
            : base(logService, domainServices)
        {
            _authentEmployeeService = authentEmployeeService;
        }

        [HttpPost("employee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AuthenticateEmployee([FromBody] AuthentDto authentDto)
        {
            if (!await IdentityServices.IdentEmployee.IsValidAuthentData(authentDto))
            {
                return Unauthorized();
            }
            return Ok(new { Token = await _authentEmployeeService.CreateToken(authentDto.Username) });
        }
    }
}
