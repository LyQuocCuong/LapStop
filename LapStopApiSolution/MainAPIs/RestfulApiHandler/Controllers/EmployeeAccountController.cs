using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.Roots;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeAccountController : RootController
    {
        public EmployeeAccountController(ILogService logService, 
                                         IServiceManager serviceManager)
                                  : base(logService, serviceManager)
        {
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
