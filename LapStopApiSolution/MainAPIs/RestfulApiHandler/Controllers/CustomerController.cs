using Azure;
using Contracts.ILog;
using Contracts.IServices;
using DTO.Creation;
using DTO.Output;
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
        public IActionResult GetAllCustomers()
        {
            List<CustomerDto> customerDtos = _serviceManager.Customer.GetAll();
            return Ok(customerDtos);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}", Name = "GetCustomerById")]
        public IActionResult GetCustomerById(Guid customerId)
        {
            CustomerDto? customerDto = _serviceManager.Customer.GetOneById(customerId);
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(customerDto);
        }

        [HttpPost]
        [Route("customers", Name = "CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] CustomerForCreationDto creationDto)
        {
            if (creationDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(CustomerForCreationDto)));
            }
            CustomerDto newCustomerDto = _serviceManager.Customer.Create(creationDto);
            return CreatedAtRoute("GetCustomerById", new { customerId = newCustomerDto.Id }, newCustomerDto);
        }

        [HttpPut]
        [Route("customers/{customerId:guid}")]
        public IActionResult UpdateCustomer(Guid customerId, [FromBody] CustomerForUpdateDto updateDto)
        {
            _serviceManager.Customer.Update(customerId, updateDto);
            return NoContent();
        }

        [HttpPatch]
        [Route("customers/{customerId:guid}")]
        public IActionResult UpdateCustomerPartially(Guid customerId, 
                                    [FromBody] JsonPatchDocument<CustomerForUpdateDto> patchDocument)
        {

            JsonPatchDocument<CustomerForUpdateDto> abc = new JsonPatchDocument<CustomerForUpdateDto>();
            abc.Replace(s => s.FirstName, "xyz");

            if (_serviceManager.Customer.IsValidId(customerId) == false)
            {
                return NotFound();
            }
            else if (patchDocument == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(JsonPatchDocument<CustomerForUpdateDto>)));
            }

            CustomerForUpdateDto updateDto = _serviceManager.Customer.GetDtoForPatch(customerId);

            abc.ApplyTo(updateDto);

            _serviceManager.Customer.Update(customerId, updateDto);

            return NoContent();
        }

    }
}
