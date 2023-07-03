using Microsoft.AspNetCore.Identity;

namespace RestfulApiHandler.Controllers.Identities
{
    [Route("api/identemployee")]
    public sealed class IdentEmployeeController : AbstractApiVer01Controller
    {
        public IdentEmployeeController(ILogService logService,
                                       IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpPost]
        [Route("register")]
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
