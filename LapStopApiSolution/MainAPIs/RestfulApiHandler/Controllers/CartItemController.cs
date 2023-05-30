using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.Roots;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class CartItemController : RootController
    {
        public CartItemController(ILogService logService, 
                                  IServiceManager serviceManager)
                           : base(logService, serviceManager)
        {
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
