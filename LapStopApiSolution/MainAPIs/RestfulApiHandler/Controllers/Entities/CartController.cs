namespace RestfulApiHandler.Controllers.Entities
{
    [ApiController]
    [Route("api")]
    public class CartController : AbstractController
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
