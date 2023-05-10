using Contracts.ILog;
using Contracts.IServices;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Output.Data;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.ActionFilters;
using Shared.Common.Messages;

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
        public async Task<IActionResult> GetAllEmployees()
        {
            IEnumerable<EmployeeDto> employees = await _serviceManager.Employee.GetAllAsync();
            return Ok(employees);
        }

        [HttpPost]
        [Route("employees", Name = "CreateEmployee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForCreationDto creationDto)
        {
            EmployeeDto newEmployeeDto = await _serviceManager.Employee.CreateAsync(creationDto);
            return CreatedAtRoute("GetEmployeeById", new { employeeId = newEmployeeDto.Id }, newEmployeeDto);
        }

        [HttpDelete]
        [Route("employees", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            if (await _serviceManager.Employee.IsValidIdAsync(employeeId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Employee.DeleteAsync(employeeId);
            return NoContent();
        }

        [HttpGet]
        [Route("employees/{employeeId:guid}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            EmployeeDto? employeeDto = await _serviceManager.Employee.GetOneByIdAsync(employeeId);
            if (employeeDto == null)
            {
                return NotFound();
            }
            return Ok(employeeDto);
        }

        [HttpPut]
        [Route("employees/{employeeId:guid}", Name = "UpdateEmployee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, [FromBody]EmployeeForUpdateDto updateDto)
        {
            if (await _serviceManager.Employee.IsValidIdAsync(employeeId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Employee.UpdateAsync(employeeId, updateDto);
            return NoContent();
        }

    }
}
