using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeAccountController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public EmployeeAccountController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("employees/accounts", Name = "GetAllEmployeeAccounts")]
        public async Task<IActionResult> GetAllEmployeeAccounts()
        {
            IEnumerable<EmployeeAccountDto> employeeAccountDtos = await _serviceManager.EmployeeAccount.GetAllAsync();
            return Ok(employeeAccountDtos);
        }

        [HttpGet]
        [Route("employees/{employeeId:guid}/account", Name = "GetEmployeeAccountByEmployeeId")]
        public async Task<IActionResult> GetEmployeeAccountByEmployeeId(Guid employeeId)
        {
            EmployeeAccountDto? employeeAccountDto = await _serviceManager.EmployeeAccount.GetOneByEmployeeIdAsync(employeeId);
            if (employeeAccountDto == null)
            {
                return NotFound();
            }
            return Ok(employeeAccountDto);
        }


    }
}
