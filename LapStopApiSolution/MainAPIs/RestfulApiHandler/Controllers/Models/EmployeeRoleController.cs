namespace RestfulApiHandler.Controllers.Models
{
    [ApiController]
    [Route("api")]
    public class EmployeeRoleController : RootController
    {
        public EmployeeRoleController(ILogService logService,
                                      IServiceManager serviceManager)
                               : base(logService, serviceManager)
        {
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
