using Microsoft.AspNetCore.Authorization;

namespace RestfulApiHandler.Controllers.Models
{
    [ApiController]
    [Route("api")]
    public class EmployeeController : AbstractController
    {
        public EmployeeController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpHead]
        [Route("employees", Name = "GetAllEmployeesHead")]
        public async Task<IActionResult> GetAllEmployeesHead([FromQuery] EmployeeRequestParam parameter)
        {
            if (parameter.MinAge > parameter.MaxAge)
            {
                return BadRequest(CommonFunctions.DisplayErrors.ReturnInvalidAgeRangeMessage);
            }

            PagedList<ExpandoForXmlObject> pagedResult = await EntityServices.Employee.GetAllAsync(parameter);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("employees", Name = "GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees([FromQuery] EmployeeRequestParam parameter)
        {
            if (parameter.MinAge > parameter.MaxAge)
            {
                return BadRequest(CommonFunctions.DisplayErrors.ReturnInvalidAgeRangeMessage);
            }

            PagedList<ExpandoForXmlObject> pagedResult = await EntityServices.Employee.GetAllAsync(parameter);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult);
        }

        [HttpGet]
        [Route("employees/{employeeId:guid}", Name = "GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            EmployeeDto? employeeDto = await EntityServices.Employee.GetOneByIdAsync(employeeId);
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
            EmployeeDto newEmployeeDto = await EntityServices.Employee.CreateAsync(creationDto);
            return CreatedAtRoute("GetEmployeeById", new { employeeId = newEmployeeDto.Id }, newEmployeeDto);
        }

        [HttpPut]
        [Route("employees/{employeeId:guid}", Name = "UpdateEmployee")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId, [FromBody] EmployeeForUpdateDto updateDto)
        {
            if (await EntityServices.Employee.IsValidIdAsync(employeeId) == false)
            {
                return NotFound();
            }
            await EntityServices.Employee.UpdateAsync(employeeId, updateDto);
            return NoContent();
        }

        [HttpPatch]
        [Route("employees/{employeeId:guid}", Name = "UpdateEmployeePartially")]
        public async Task<IActionResult> UpdateEmployeePartially(Guid employeeId,
                                            JsonPatchDocument<EmployeeForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(CommonFunctions.DisplayErrors.ReturnNullObjectMessage(nameof(JsonPatchDocument<EmployeeForUpdateDto>)));
            }
            if (await EntityServices.Employee.IsValidIdAsync(employeeId) == false)
            {
                return NotFound();
            }

            // get data from DB
            EmployeeForUpdateDto updateDto = await EntityServices.Employee.GetDtoForPatchAsync(employeeId);

            // apply Patch operation + log Errors in ModelState
            patchDocument.ApplyTo(updateDto, ModelState);

            TryValidateModel(updateDto);

            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }

            // update
            await EntityServices.Employee.UpdateAsync(employeeId, updateDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("employees/{employeeId:guid}", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            if (await EntityServices.Employee.IsValidIdAsync(employeeId) == false)
            {
                return NotFound();
            }
            await EntityServices.Employee.DeleteAsync(employeeId);
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
