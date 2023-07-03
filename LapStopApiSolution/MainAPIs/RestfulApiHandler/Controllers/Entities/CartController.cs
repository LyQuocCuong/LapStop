namespace RestfulApiHandler.Controllers.Entities
{
    public sealed class CartController : AbstractApiVer01Controller
    {
        public CartController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("carts", Name = "GetAllCarts")]
        public async Task<IActionResult> GetAllCarts()
        {
            IEnumerable<CartDto> cartDtos = await EntityServices.Cart.GetAllAsync();
            return Ok(cartDtos);
        }

        [HttpGet]
        [Route("customers/{customerId:guid}/cart", Name = "GetCartByCustomerId")]
        public async Task<IActionResult> GetCartByCustomerId(Guid customerId)
        {
            CartDto? cartDto = await EntityServices.Cart.GetOneByCustomerIdAsync(customerId);
            if (cartDto == null)
            {
                return NotFound();
            }
            return Ok(cartDto);
        }

    }
}
