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
        [Route("employees/accounts")]
        public IActionResult GetAll()
        {
            List<EmployeeAccountDto> employeeAccountDtos = _serviceManager.EmployeeAccount.GetAll(isTrackChanges: false);
            return Ok(employeeAccountDtos);
        }

        [HttpGet]
        [Route("employees/{id:guid}/account")]
        public IActionResult GetByEmployeeId(Guid id)
        {
            EmployeeAccountDto? employeeAccountDto = _serviceManager.EmployeeAccount.GetByEmployeeId(isTrackChanges: false, id);
            if (employeeAccountDto == null)
            {
                return NotFound();
            }
            return Ok(employeeAccountDto);
        }


    }
}
