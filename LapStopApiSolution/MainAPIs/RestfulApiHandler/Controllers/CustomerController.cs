using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("customers/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            CustomerDto? customerDto = _serviceManager.Customer.GetById(isTrackChanges: false, id);
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(customerDto);
        }

    }
}
