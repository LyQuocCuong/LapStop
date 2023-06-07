namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class CustomerController : RootController
    {
        public CustomerController(ILogService logService, 
                                  IServiceManager serviceManager)
                           : base(logService, serviceManager)
        {
        }

        [HttpHead]
        [Route("customers", Name = "GetAllCustomersHead")]
        public async Task<IActionResult> GetAllCustomersHead([FromQuery]CustomerRequestParam parameters)
        {
            PagedList<ExpandoForXmlObject> pagedResult = await _serviceManager.Customer.GetAllAsync(parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok();
        }

        [HttpGet]
        [Route("customers", Name = "GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers([FromQuery] CustomerRequestParam parameters)
        {
            PagedList<ExpandoForXmlObject> pagedResult = await _serviceManager.Customer.GetAllAsync(parameters);

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
                return BadRequest(CommonFunctions.DisplayErrors.ReturnNullObjectMessage(nameof(JsonPatchDocument<CustomerForUpdateDto>)));
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
