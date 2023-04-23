using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
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
        [Route("customers/{customerId}/account")]
        public IActionResult GetByCustomerId(bool isTrackChanges, Guid customerId)
        {
            CustomerAccountDto? customerAccountDto = _serviceManager.CustomerAccount.GetByCustomerId(isTrackChanges, customerId);
            if (customerAccountDto == null)
            {
                return NotFound();
            }
            return Ok(customerAccountDto);
        }


    }
}
