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

        [HttpGet("products/{id}/galleries")]
        public IActionResult GetByProductId(Guid id)
        {
            List<ProductGalleryDto> productGalleryDtos = _serviceManager.ProductGallery.GetByProductId(isTrackChanges: false, id);
            return Ok(productGalleryDtos);
        }


    }
}
