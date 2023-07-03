namespace RestfulApiHandler.Controllers.Entities
{
    public sealed class ProductGalleryController : AbstractApiVer01Controller
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
