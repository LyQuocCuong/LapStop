using Contracts.ILog;
using Contracts.IServices;
using DTO.Creation;
using DTO.Output;
using DTO.Parameters;
using DTO.Update;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Messages;

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

        [HttpGet]
        [Route("customers", Name = "GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers([FromQuery]CustomerParameters parameters)
        {
            IEnumerable<CustomerDto> customerDtos = await _serviceManager.Customer.GetAllAsync(parameters);
            return Ok(customerDtos);
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
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreationDto creationDto)
        {
            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }
            if (creationDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(CustomerForCreationDto)));
            }
            CustomerDto newCustomerDto = await _serviceManager.Customer.CreateAsync(creationDto);
            return CreatedAtRoute("GetCustomerById", new { customerId = newCustomerDto.Id }, newCustomerDto);
        }

        [HttpPut]
        [Route("customers/{customerId:guid}")]
        public async Task<IActionResult> UpdateCustomer(Guid customerId, [FromBody] CustomerForUpdateDto updateDto)
        {
            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }
            if (updateDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(CustomerForUpdateDto)));
            }
            if (await _serviceManager.Customer.IsValidIdAsync(customerId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Customer.UpdateAsync(customerId, updateDto);
            return NoContent();
        }

        [HttpPatch]
        [Route("customers/{customerId:guid}")]
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

    }
}
