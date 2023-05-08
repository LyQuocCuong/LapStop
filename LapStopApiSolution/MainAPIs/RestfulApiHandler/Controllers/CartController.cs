using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
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
        public async Task<IActionResult> GetAllCarts()
        {
            IEnumerable<CartDto> cartDtos = await _serviceManager.Cart.GetAllAsync();
            return Ok(cartDtos);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}/cart", Name = "GetCartByCustomerId")]
        public async Task<IActionResult> GetCartByCustomerId(Guid customerId)
        {
            CartDto? cartDto = await _serviceManager.Cart.GetOneByCustomerIdAsync(customerId);
            if (cartDto == null)
            {
                return NotFound();
            }
            return Ok(cartDto);
        }

    }
}
