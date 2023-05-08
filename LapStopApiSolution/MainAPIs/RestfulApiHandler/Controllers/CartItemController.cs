using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class CartItemController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public CartItemController(IServiceManager serviceManager, ILogService logService)
        {
            _serviceManager = serviceManager;
            _logService = logService;
        }

        [HttpGet]
        [Route("carts/{cartId:guid}/cartitems", Name = "GetAllCartItemsByCartId")]
        public async Task<IActionResult> GetAllCartItemsByCartId(Guid cartId)
        {
            IEnumerable<CartItemDto> cartItemDtos = await _serviceManager.CartItem.GetAllByCartIdAsync(cartId);
            return Ok(cartItemDtos);
        }

    }
}
