using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api/employeeroles")]
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
        public IActionResult GetAll()
        {
            List<EmployeeRoleDto> employeeRoleDtos = _serviceManager.EmployeeRole.GetAll(isTrackChanges: false);
            return Ok(employeeRoleDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            //Using example: throw new Exception("Hello Ex");
            EmployeeRoleDto? employeeRoleDto = _serviceManager.EmployeeRole.GetById(isTrackChanges: false, id);
            if (employeeRoleDto == null)
            {
                return NotFound();
            }
            return Ok(employeeRoleDto);
        }

    }
}
