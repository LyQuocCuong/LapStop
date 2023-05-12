using Contracts.ILog;
using Contracts.IServices;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.ActionFilters;
using Shared.Common.Messages;
using System.Dynamic;
using System.Text.Json;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public CustomerController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpHead]
        [HttpGet]
        [Route("customers", Name = "GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers([FromQuery]CustomerParameters parameters)
        {
            PagedList<ExpandoObject> pagedResult = await _serviceManager.Customer.GetAllAsync(parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}", Name = "GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(Guid customerId)
        {
            CustomerDto? customerDto = await _serviceManager.Customer.GetOneByIdAsync(customerId);
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(customerDto);
        }

        [HttpPost]
        [Route("customers", Name = "CreateCustomer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreationDto creationDto)
        {
            CustomerDto newCustomerDto = await _serviceManager.Customer.CreateAsync(creationDto);
            return CreatedAtRoute("GetCustomerById", new { customerId = newCustomerDto.Id }, newCustomerDto);
        }

        [HttpPut]
        [Route("customers/{customerId:guid}", Name = "UpdateCustomer")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCustomer(Guid customerId, [FromBody] CustomerForUpdateDto updateDto)
        {
            if (await _serviceManager.Customer.IsValidIdAsync(customerId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Customer.UpdateAsync(customerId, updateDto);
            return NoContent();
        }

        [HttpPatch]
        [Route("customers/{customerId:guid}", Name = "UpdateCustomerPartially")]
        public async Task<IActionResult> UpdateCustomerPartially(Guid customerId, 
                                    [FromBody] JsonPatchDocument<CustomerForUpdateDto> patchDocument)
        {

            JsonPatchDocument<CustomerForUpdateDto> abc = new JsonPatchDocument<CustomerForUpdateDto>();
            abc.Replace(s => s.FirstName, "xyz");

            if (await _serviceManager.Customer.IsValidIdAsync(customerId) == false)
            {
                return NotFound();
            }
            else if (patchDocument == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(JsonPatchDocument<CustomerForUpdateDto>)));
            }

            CustomerForUpdateDto updateDto = await _serviceManager.Customer.GetDtoForPatchAsync(customerId);

            abc.ApplyTo(updateDto);

            await _serviceManager.Customer.UpdateAsync(customerId, updateDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("customers/{customerId:guid}", Name = "DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(Guid customerId)
        {
            if (await _serviceManager.Customer.IsValidIdAsync(customerId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Customer.DeleteAsync(customerId);
            return NoContent();
        }

        [HttpOptions]
        [Route("customers", Name = "GetCustomerOptions")]
        public IActionResult GetCustomerOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, PUT, PATCH");
            return Ok();
        }

    }
}
