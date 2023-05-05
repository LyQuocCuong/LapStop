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

        [HttpGet]
        [Route("carts", Name = "GetAllCarts")]
        public IActionResult GetAllCarts()
        {
            List<CartDto> cartDtos = _serviceManager.Cart.GetAll();
            return Ok(cartDtos);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}/cart", Name = "GetCartByCustomerId")]
        public IActionResult GetCartByCustomerId(Guid customerId)
        {
            CartDto? cartDto = _serviceManager.Cart.GetOneByCustomerId(customerId);
            if (cartDto == null)
            {
                return NotFound();
            }
            return Ok(cartDto);
        }

    }
}
