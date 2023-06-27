namespace RestfulApiHandler.Controllers.Entities
{
    [ApiController]
    [Route("api")]
    public class CartItemController : AbstractController
    {
        public CartItemController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("carts/{cartId:guid}/cartitems", Name = "GetAllCartItemsByCartId")]
        public async Task<IActionResult> GetAllCartItemsByCartId(Guid cartId)
        {
            IEnumerable<CartItemDto> cartItemDtos = await EntityServices.CartItem.GetAllByCartIdAsync(cartId);
            return Ok(cartItemDtos);
        }

    }
}
