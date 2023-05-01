using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductGalleryController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public ProductGalleryController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("products/{productId:guid}/galleries", Name = "GetAllProductGalleriesByProductId")]
        public IActionResult GetAllProductGalleriesByProductId(Guid productId)
        {
            List<ProductGalleryDto> productGalleryDtos = _serviceManager.ProductGallery.GetAllByProductId(isTrackChanges: false, productId);
            return Ok(productGalleryDtos);
        }


    }
}
