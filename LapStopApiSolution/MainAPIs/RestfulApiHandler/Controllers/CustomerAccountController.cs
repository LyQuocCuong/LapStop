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
        public async Task<IActionResult> GetAllCustomerAccounts()
        {
            IEnumerable<CustomerAccountDto> customerAccountDtos = await _serviceManager.CustomerAccount.GetAllAsync();
            return Ok(customerAccountDtos);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}/account", Name = "GetCustomerAccountByCustomerId")]
        public async Task<IActionResult> GetCustomerAccountByCustomerId(Guid customerId)
        {
            CustomerAccountDto? customerAccountDto = await _serviceManager.CustomerAccount.GetOneByCustomerIdAsync(customerId);
            if (customerAccountDto == null)
            {
                return NotFound();
            }
            return Ok(customerAccountDto);
        }

        [HttpPost]
        [Route("customers/{customerId:guid}/account", Name = "CreateCustomerAccount")]
        public async Task<IActionResult> CreateCustomerAccount(Guid customerId, [FromBody] CustomerAccountForCreationDto creationDto)
        {
            if (creationDto == null)
            {
                return BadRequest(Shared.Common.Messages.CommonMessages.ERROR.NullObject(nameof(CustomerAccountForCreationDto)));
            }
            CustomerAccountDto newCustomerAccountDto = await _serviceManager.CustomerAccount.CreateAsync(customerId, creationDto);
            return CreatedAtRoute("GetCustomerAccountByCustomerId", new { customerId = newCustomerAccountDto.CustomerId }, newCustomerAccountDto);
        }

        [HttpPut]
        [Route("customers/{customerId:guid}/account", Name = "UpdateCustomerAccount")]
        public async Task<IActionResult> UpdateCustomerAccount(Guid customerId, [FromBody] CustomerAccountForUpdateDto updateDto)
        {
            await _serviceManager.CustomerAccount.UpdateAsync(customerId, updateDto);
            return NoContent();
        }

    }
}
