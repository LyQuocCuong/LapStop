using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public EmployeeController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("employees")]
        public IActionResult GetAll()
        {
            List<EmployeeDto> employees = _serviceManager.Employee.GetAll(isTrackChanges: false);
            return Ok(employees);
        }

        [HttpGet]
        [Route("employees/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            EmployeeDto? employeeDto = _serviceManager.Employee.GetById(isTrackChanges: false, id);
            if (employeeDto == null)
            {
                return NotFound();
            }
            return Ok(employeeDto);
        }

    }
}
