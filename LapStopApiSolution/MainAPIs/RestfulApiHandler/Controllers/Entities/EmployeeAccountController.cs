namespace RestfulApiHandler.Controllers.Entities
{
    [ApiController]
    [Route("api")]
    public class EmployeeAccountController : AbstractController
    {
        public EmployeeAccountController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("employees/accounts", Name = "GetAllEmployeeAccounts")]
        public async Task<IActionResult> GetAllEmployeeAccounts()
        {
            IEnumerable<EmployeeAccountDto> employeeAccountDtos = await EntityServices.EmployeeAccount.GetAllAsync();
            return Ok(employeeAccountDtos);
        }

        [HttpGet]
        [Route("employees/{employeeId:guid}/account", Name = "GetEmployeeAccountByEmployeeId")]
        public async Task<IActionResult> GetEmployeeAccountByEmployeeId(Guid employeeId)
        {
            EmployeeAccountDto? employeeAccountDto = await EntityServices.EmployeeAccount.GetOneByEmployeeIdAsync(employeeId);
            if (employeeAccountDto == null)
            {
                return NotFound();
            }
            return Ok(employeeAccountDto);
        }


    }
}
