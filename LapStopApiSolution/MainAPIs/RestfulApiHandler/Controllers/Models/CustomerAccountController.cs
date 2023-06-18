﻿namespace RestfulApiHandler.Controllers.Models
{
    [ApiController]
    [Route("api")]
    public class CustomerAccountController : RootController
    {
        public CustomerAccountController(ILogService logService,
                                         IServiceManager serviceManager)
                                  : base(logService, serviceManager)
        {
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
                return BadRequest(CommonFunctions.DisplayErrors.ReturnNullObjectMessage(nameof(CustomerAccountForCreationDto)));
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