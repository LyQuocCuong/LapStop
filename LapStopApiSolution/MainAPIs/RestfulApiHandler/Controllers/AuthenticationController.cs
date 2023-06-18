using Contracts.Authentication;
using DTO.Input.FromBody.Authentication;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api/authenticate")]
    public sealed class AuthenticationController : RootController
    {
        private readonly IAuthentService _authenticationService;

        public AuthenticationController(ILogService logService, 
                                        IServiceManager serviceManager, 
                                        IAuthentService authenticationService)
            : base(logService, serviceManager)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("employee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))] 
        public async Task<IActionResult> AuthenticateEmployee([FromBody] EmployeeForAuthentDto authentDto) 
        {
            if (!await _serviceManager.IdentEmployee.Validate(authentDto))
            {
                return Unauthorized();
            }
            return Ok(new { Token = await _authenticationService.CreateToken(authentDto.Username) }); 
        }
    }
}
