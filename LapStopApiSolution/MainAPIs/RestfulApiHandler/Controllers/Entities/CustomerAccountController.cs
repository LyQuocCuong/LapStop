namespace RestfulApiHandler.Controllers.Entities
{
    public sealed class CustomerAccountController : AbstractApiVer01Controller
    {
        public CustomerAccountController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("customers/accounts", Name = "GetAllCustomerAccounts")]
        public async Task<IActionResult> GetAllCustomerAccounts()
        {
            IEnumerable<CustomerAccountDto> customerAccountDtos = await EntityServices.CustomerAccount.GetAllAsync();
            return Ok(customerAccountDtos);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}/account", Name = "GetCustomerAccountByCustomerId")]
        public async Task<IActionResult> GetCustomerAccountByCustomerId(Guid customerId)
        {
            CustomerAccountDto? customerAccountDto = await EntityServices.CustomerAccount.GetOneByCustomerIdAsync(customerId);
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
            CustomerAccountDto newCustomerAccountDto = await EntityServices.CustomerAccount.CreateAsync(customerId, creationDto);
            return CreatedAtRoute("GetCustomerAccountByCustomerId", new { customerId = newCustomerAccountDto.CustomerId }, newCustomerAccountDto);
        }

        [HttpPut]
        [Route("customers/{customerId:guid}/account", Name = "UpdateCustomerAccount")]
        public async Task<IActionResult> UpdateCustomerAccount(Guid customerId, [FromBody] CustomerAccountForUpdateDto updateDto)
        {
            await EntityServices.CustomerAccount.UpdateAsync(customerId, updateDto);
            return NoContent();
        }

    }
}
