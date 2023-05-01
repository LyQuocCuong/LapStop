using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeRoleController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public EmployeeRoleController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("employeeroles", Name = "GetAllEmployeeRoles")]
        public IActionResult GetAllEmployeeRoles()
        {
            List<EmployeeRoleDto> employeeRoleDtos = _serviceManager.EmployeeRole.GetAll(isTrackChanges: false);
            return Ok(employeeRoleDtos);
        }

        [HttpGet]
        [Route("employeeroles/{employeeRoleId:guid}", Name = "GetEmployeeRoleById")]
        public IActionResult GetEmployeeRoleById(Guid employeeRoleId)
        {
            EmployeeRoleDto? employeeRoleDto = _serviceManager.EmployeeRole.GetOneById(isTrackChanges: false, employeeRoleId);
            if (employeeRoleDto == null)
            {
                return NotFound();
            }
            return Ok(employeeRoleDto);
        }

    }
}
