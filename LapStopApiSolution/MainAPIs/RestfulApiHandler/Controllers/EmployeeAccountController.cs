using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
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
        public IActionResult GetAllEmployeeAccounts()
        {
            List<EmployeeAccountDto> employeeAccountDtos = _serviceManager.EmployeeAccount.GetAll(isTrackChanges: false);
            return Ok(employeeAccountDtos);
        }

        [HttpGet]
        [Route("employees/{employeeId:guid}/account", Name = "GetEmployeeAccountByEmployeeId")]
        public IActionResult GetEmployeeAccountByEmployeeId(Guid employeeId)
        {
            EmployeeAccountDto? employeeAccountDto = _serviceManager.EmployeeAccount.GetOneByEmployeeId(isTrackChanges: false, employeeId);
            if (employeeAccountDto == null)
            {
                return NotFound();
            }
            return Ok(employeeAccountDto);
        }


    }
}
