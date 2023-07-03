namespace RestfulApiHandler.Controllers.Entities
{
    public sealed class EmployeeRoleController : AbstractApiVer01Controller
    {
        public EmployeeRoleController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("employeeroles", Name = "GetAllEmployeeRoles")]
        public async Task<IActionResult> GetAllEmployeeRoles()
        {
            IEnumerable<EmployeeRoleDto> employeeRoleDtos = await EntityServices.EmployeeRole.GetAllAsync();
            return Ok(employeeRoleDtos);
        }

        [HttpGet]
        [Route("employeeroles/{employeeRoleId:guid}", Name = "GetEmployeeRoleById")]
        public async Task<IActionResult> GetEmployeeRoleById(Guid employeeRoleId)
        {
            EmployeeRoleDto? employeeRoleDto = await EntityServices.EmployeeRole.GetOneByIdAsync(employeeRoleId);
            if (employeeRoleDto == null)
            {
                return NotFound();
            }
            return Ok(employeeRoleDto);
        }

    }
}
