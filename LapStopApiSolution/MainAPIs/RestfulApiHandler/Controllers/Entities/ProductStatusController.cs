namespace RestfulApiHandler.Controllers.Entities
{
    [ApiController]
    [Route("api")]
    public class ProductStatusController : AbstractController
    {
        public ProductStatusController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("productstatuses", Name = "GetAllProductStatuses")]
        public async Task<IActionResult> GetAllProductStatuses()
        {
            IEnumerable<ProductStatusDto> productStatusDtos = await EntityServices.ProductStatus.GetAllAsync();
            return Ok(productStatusDtos);
        }

        [HttpGet]
        [Route("productstatuses/{productStatusId:guid}", Name = "GetProductStatusById")]
        public async Task<IActionResult> GetProductStatusById(Guid productStatusId)
        {
            ProductStatusDto? productStatusDto = await EntityServices.ProductStatus.GetOneByIdAsync(productStatusId);
            if (productStatusDto == null)
            {
                return NotFound();
            }
            return Ok(productStatusDto);
        }

    }
}
