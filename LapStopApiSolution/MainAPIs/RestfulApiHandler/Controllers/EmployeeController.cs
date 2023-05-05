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
        [Route("employees", Name = "GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            List<EmployeeDto> employees = _serviceManager.Employee.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        [Route("employees/{employeeId:guid}", Name = "GetEmployeeById")]
        public IActionResult GetEmployeeById(Guid employeeId)
        {
            EmployeeDto? employeeDto = _serviceManager.Employee.GetOneById(employeeId);
            if (employeeDto == null)
            {
                return NotFound();
            }
            return Ok(employeeDto);
        }

    }
}
