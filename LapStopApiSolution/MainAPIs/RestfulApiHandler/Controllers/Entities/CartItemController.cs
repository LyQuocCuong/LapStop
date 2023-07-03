namespace RestfulApiHandler.Controllers.Entities
{
    public sealed class CartItemController : AbstractApiVer01Controller
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
