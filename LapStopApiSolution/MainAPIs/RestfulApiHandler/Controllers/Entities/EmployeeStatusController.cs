﻿namespace RestfulApiHandler.Controllers.Entities
{
    public sealed class EmployeeStatusController : AbstractApiVer01Controller
    {
        public EmployeeStatusController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("employeestatuses", Name = "GetAllEmployeeStatuses")]
        public async Task<IActionResult> GetAllEmployeeStatuses()
        {
            IEnumerable<EmployeeStatusDto> employeeStatusDtos = await EntityServices.EmployeeStatus.GetAllAsync();
            return Ok(employeeStatusDtos);
        }

        [HttpGet]
        [Route("employeestatuses/{employeeStatusId:guid}", Name = "GetEmployeeStatusById")]
        public async Task<IActionResult> GetEmployeeStatusById(Guid employeeStatusId)
        {
            EmployeeStatusDto? employeeStatusDto = await EntityServices.EmployeeStatus.GetOneByIdAsync(employeeStatusId);
            if (employeeStatusDto == null)
            {
                return NotFound();
            }
            return Ok(employeeStatusDto);
        }

    }
}
