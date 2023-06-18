namespace RestfulApiHandler.Controllers.Models
{
    [ApiController]
    [Route("api")]
    public class EmployeeStatusController : RootController
    {
        public EmployeeStatusController(ILogService logService,
                                        IServiceManager serviceManager)
                                 : base(logService, serviceManager)
        {
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
