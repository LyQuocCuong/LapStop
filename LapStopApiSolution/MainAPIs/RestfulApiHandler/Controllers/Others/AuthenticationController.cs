using Contracts.Authentication;
using Domains.IdentityModels;
using DTO.Input.FromBody.Authentication;

namespace RestfulApiHandler.Controllers.Others
{
    [ApiController]
    [Route("api/authenticate")]
    public sealed class AuthenticationController : RootController
    {
        private readonly IAuthentService<IdentEmployee> _authentEmployeeService;

        public AuthenticationController(ILogService logService,
                                        IServiceManager serviceManager,
                                        IAuthentService<IdentEmployee> authentEmployeeService)
            : base(logService, serviceManager)
        {
            _authentEmployeeService = authentEmployeeService;
        }

        [HttpPost("employee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AuthenticateEmployee([FromBody] AuthentDto authentDto)
        {
            if (!await _serviceManager.IdentEmployee.IsValidAuthentData(authentDto))
            {
                return Unauthorized();
            }
            return Ok(new { Token = await _authentEmployeeService.CreateToken(authentDto.Username) });
        }
    }
}
