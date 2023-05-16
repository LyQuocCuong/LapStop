using Contracts.ILog;
using Contracts.IServices;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.ActionFilters;
using Shared.Common.Messages;
using Shared.CustomModels.DynamicObjects;
using System.Dynamic;
using System.Text.Json;

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

        [HttpHead]
        [Route("employees", Name = "GetAllEmployeesHead")]
        public async Task<IActionResult> GetAllEmployeesHead([FromQuery]EmployeeParameter parameter)
        {
            if (parameter.MinAge > parameter.MaxAge)
            {
                return BadRequest(CommonMessages.ERROR.InvalidAgeRange);
            }

            PagedList<ShapedModel> pagedResult = await _serviceManager.Employee.GetAllAsync(parameter);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok();
        }

        [HttpGet]
        [Route("employees", Name = "GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees([FromQuery] EmployeeParameter parameter)
        {
            if (parameter.MinAge > parameter.MaxAge)
            {
                return BadRequest(CommonMessages.ERROR.InvalidAgeRange);
            }

            PagedList<ShapedModel> pagedResult = await _serviceManager.Employee.GetAllAsync(parameter);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult);
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

        [HttpPost]
        [Route("employees", Name = "CreateEmployee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForCreationDto creationDto)
        {
            EmployeeDto newEmployeeDto = await _serviceManager.Employee.CreateAsync(creationDto);
            return CreatedAtRoute("GetEmployeeById", new { employeeId = newEmployeeDto.Id }, newEmployeeDto);
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

        [HttpPatch]
        [Route("employees/{employeeId:guid}", Name = "UpdateEmployeePartially")]
        public async Task<IActionResult> UpdateEmployeePartially(Guid employeeId,
                                            JsonPatchDocument<EmployeeForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(JsonPatchDocument<EmployeeForUpdateDto>)));
            }
            if (await _serviceManager.Employee.IsValidIdAsync(employeeId) == false)
            {
                return NotFound();
            }

            // get data from DB
            EmployeeForUpdateDto updateDto = await _serviceManager.Employee.GetDtoForPatchAsync(employeeId);
            
            // apply Patch operation + log Errors in ModelState
            patchDocument.ApplyTo(updateDto, ModelState);

            TryValidateModel(updateDto);

            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }

            // update
            await _serviceManager.Employee.UpdateAsync(employeeId, updateDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("employees/{employeeId:guid}", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            if (await _serviceManager.Employee.IsValidIdAsync(employeeId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Employee.DeleteAsync(employeeId);
            return NoContent();
        }

        [HttpOptions]
        [Route("employees", Name = "GetEmployeeOptions")]
        public IActionResult GetEmployeeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
