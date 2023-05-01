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
        [Route("customers/accounts", Name = "GetAllCustomerAccounts")]
        public IActionResult GetAllCustomerAccounts()
        {
            List<CustomerAccountDto> customerAccountDtos = _serviceManager.CustomerAccount.GetAll(isTrackChanges: false);
            return Ok(customerAccountDtos);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}/account", Name = "GetCustomerAccountByCustomerId")]
        public IActionResult GetCustomerAccountByCustomerId(Guid customerId)
        {
            CustomerAccountDto? customerAccountDto = _serviceManager.CustomerAccount.GetOneByCustomerId(isTrackChanges: false, customerId);
            if (customerAccountDto == null)
            {
                return NotFound();
            }
            return Ok(customerAccountDto);
        }

        [HttpPost]
        [Route("customers/{customerId:guid}/account", Name = "CreateCustomerAccount")]
        public IActionResult CreateCustomerAccount(Guid customerId, [FromBody] CustomerAccountForCreationDto creationDto)
        {
            if (creationDto == null)
            {
                return BadRequest(Shared.Common.Messages.CommonMessages.ERROR.NullObject(nameof(CustomerAccountForCreationDto)));
            }
            CustomerAccountDto newCustomerAccountDto = _serviceManager.CustomerAccount.Create(customerId, creationDto);
            return CreatedAtRoute("GetCustomerAccountByCustomerId", new { customerId = newCustomerAccountDto.CustomerId }, newCustomerAccountDto);
        }

        [HttpPut]
        [Route("customers/{customerId:guid}/account", Name = "UpdateCustomerAccount")]
        public IActionResult UpdateCustomerAccount(Guid customerId, [FromBody] CustomerAccountForUpdateDto updateDto)
        {
            _serviceManager.CustomerAccount.Update(customerId, updateDto);
            return NoContent();
        }

    }
}
