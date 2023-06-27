namespace RestfulApiHandler.Controllers.Entities
{
    [ApiController]
    [Route("api")]
    public class ProductGalleryController : AbstractController
    {
        public ProductGalleryController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("products/{productId:guid}/galleries", Name = "GetAllProductGalleriesByProductId")]
        public async Task<IActionResult> GetAllProductGalleriesByProductId(Guid productId)
        {
            IEnumerable<ProductGalleryDto> productGalleryDtos = await EntityServices.ProductGallery.GetAllByProductIdAsync(productId);
            return Ok(productGalleryDtos);
        }


    }
}
