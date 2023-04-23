using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class CartController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public CartController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [Route("customers/{customerId: guid}/cart")]
        public IActionResult GetByCustomerId(Guid customerId)
        {
            CartDto? cartDto = _serviceManager.Cart.GetByCustomerId(isTrackChanges: false, customerId);
            if (cartDto == null)
            {
                return NotFound();
            }
            return Ok(cartDto);
        }

        [HttpGet("carts")]
        public IActionResult GetAll()
        {
            List<CartDto> cartDtos = _serviceManager.Cart.GetAll(isTrackChanges: false);
            return Ok(cartDtos);
        }

    }
}
