namespace RestfulApiHandler.Controllers.Models
{
    [ApiController]
    [Route("api")]
    public class CartController : RootController
    {
        public CartController(ILogService logService,
                              IServiceManager serviceManager)
                       : base(logService, serviceManager)
        {
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
