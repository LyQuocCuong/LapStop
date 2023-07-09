using Microsoft.AspNetCore.Identity;

namespace RestfulApiHandler.Controllers.Identities
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/identity/employee")]
    [ApiExplorerSettings(GroupName = "v2")]
    public sealed class IdentEmployeeController : AbstractController
    {
        public IdentEmployeeController(ILogService logService,
                                       IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterIdentEmployee([FromBody] EmployeeForRegistrationDto registrationDto)
        {
            IdentityResult result = await IdentityServices.IdentEmployee.CreateAsync(registrationDto, registrationDto.Password);

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
