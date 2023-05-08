using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
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
        public async Task<IActionResult> GetAllEmployeeRoles()
        {
            IEnumerable<EmployeeRoleDto> employeeRoleDtos = await _serviceManager.EmployeeRole.GetAllAsync();
            return Ok(employeeRoleDtos);
        }

        [HttpGet]
        [Route("employeeroles/{employeeRoleId:guid}", Name = "GetEmployeeRoleById")]
        public async Task<IActionResult> GetEmployeeRoleById(Guid employeeRoleId)
        {
            EmployeeRoleDto? employeeRoleDto = await _serviceManager.EmployeeRole.GetOneByIdAsync(employeeRoleId);
            if (employeeRoleDto == null)
            {
                return NotFound();
            }
            return Ok(employeeRoleDto);
        }

    }
}
