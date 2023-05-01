using Contracts.ILog;
using Contracts.IServices;
using DTO.Creation;
using DTO.Output;
using DTO.Update;
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
        [Route("customers")]
        public IActionResult GetAll()
        {
            List<CustomerDto> customerDtos = _serviceManager.Customer.GetAll(isTrackChanges: false);
            return Ok(customerDtos);
        }

        [HttpPost]
        [Route("customers")]
        public IActionResult CreateCustomer([FromBody] CustomerForCreationDto creationDto)
        {
            if (creationDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(CustomerForCreationDto)));
            }
            CustomerDto newCustomerDto = _serviceManager.Customer.CreateCustomer(creationDto);
            return CreatedAtRoute("GetCustomerById", new { id = newCustomerDto.Id }, newCustomerDto);
        }

        [HttpGet]
        [Route("customers/{id:guid}", Name = "GetCustomerById")]
        public IActionResult GetById(Guid id)
        {
            CustomerDto? customerDto = _serviceManager.Customer.GetById(isTrackChanges: false, id);
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(customerDto);
        }

        [HttpPut]
        [Route("customers/{id:guid}")]
        public IActionResult UpdateCustomer(Guid id, [FromBody] CustomerForUpdateDto updateDto)
        {
            _serviceManager.Customer.UpdateCustomer(id, updateDto);
            return NoContent();
        }

    }
}
