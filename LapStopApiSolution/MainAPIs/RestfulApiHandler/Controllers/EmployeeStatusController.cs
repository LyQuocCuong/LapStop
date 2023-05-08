using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public EmployeeStatusController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("employeestatuses", Name = "GetAllEmployeeStatuses")]
        public async Task<IActionResult> GetAllEmployeeStatuses()
        {
            IEnumerable<EmployeeStatusDto> employeeStatusDtos = await _serviceManager.EmployeeStatus.GetAllAsync();
            return Ok(employeeStatusDtos);
        }

        [HttpGet]
        [Route("employeestatuses/{employeeStatusId:guid}", Name = "GetEmployeeStatusById")]
        public async Task<IActionResult> GetEmployeeStatusById(Guid employeeStatusId)
        {
            EmployeeStatusDto? employeeStatusDto = await _serviceManager.EmployeeStatus.GetOneByIdAsync(employeeStatusId);
            if (employeeStatusDto == null)
            {
                return NotFound();
            }
            return Ok(employeeStatusDto);
        }

    }
}
