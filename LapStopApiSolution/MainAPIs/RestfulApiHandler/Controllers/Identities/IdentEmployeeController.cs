using Microsoft.AspNetCore.Identity;

namespace RestfulApiHandler.Controllers.Identities
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/identity/employee")]
    public sealed class IdentEmployeeController : RootController
    {
        public IdentEmployeeController(ILogService logService,
                                       IServiceManager serviceManager)
            : base(logService, serviceManager)
        {
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterIdentEmployee([FromBody] EmployeeForRegistrationDto registrationDto)
        {
            IdentityResult result = await _serviceManager.IdentEmployee.Create(registrationDto, registrationDto.Password);

            if (result.Succeeded == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
    }
}
