using Contracts.Constants;
using Contracts.ILog;
using Contracts.IServices;
using DTO.Creation;
using DTO.Output;
using DTO.Update;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerAccountController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public CustomerAccountController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("customers/accounts")]
        public IActionResult GetAll()
        {
            List<CustomerAccountDto> customerAccountDtos = _serviceManager.CustomerAccount.GetAll(isTrackChanges: false);
            return Ok(customerAccountDtos);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}/account", Name = "GetAccountByCustomerId")]
        public IActionResult GetByCustomerId(bool isTrackChanges, Guid customerId)
        {
            CustomerAccountDto? customerAccountDto = _serviceManager.CustomerAccount.GetByCustomerId(isTrackChanges, customerId);
            if (customerAccountDto == null)
            {
                return NotFound();
            }
            return Ok(customerAccountDto);
        }

        [HttpPost]
        [Route("customers/{customerId:guid}/account")]
        public IActionResult CreateCustomerAccount(Guid customerId, [FromBody] CustomerAccountForCreationDto creationDto)
        {
            if (creationDto == null)
            {
                return BadRequest(ConstMessages.OBJECT_IS_NULL(nameof(CustomerAccountForCreationDto)));
            }
            CustomerAccountDto newCustomerAccountDto = _serviceManager.CustomerAccount.CreateCustomerAccount(customerId, creationDto);
            return CreatedAtRoute("GetAccountByCustomerId", new { customerId = newCustomerAccountDto.CustomerId }, newCustomerAccountDto);
        }

        [HttpPut]
        [Route("customers/{customerId:guid}/account")]
        public IActionResult UpdateCustomerAccount(Guid customerId, [FromBody] CustomerAccountForUpdateDto updateDto)
        {
            _serviceManager.CustomerAccount.UpdateCustomerAccount(customerId, updateDto);
            return NoContent();
        }

    }
}
