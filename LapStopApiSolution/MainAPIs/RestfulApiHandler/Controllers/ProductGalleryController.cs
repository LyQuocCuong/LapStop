using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.Roots;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductGalleryController : RootController
    {
        public ProductGalleryController(ILogService logService, 
                                        IServiceManager serviceManager)
                                 : base(logService, serviceManager)
        {
        }

        [HttpGet]
        [Route("products/{productId:guid}/galleries", Name = "GetAllProductGalleriesByProductId")]
        public async Task<IActionResult> GetAllProductGalleriesByProductId(Guid productId)
        {
            IEnumerable<ProductGalleryDto> productGalleryDtos = await _serviceManager.ProductGallery.GetAllByProductIdAsync(productId);
            return Ok(productGalleryDtos);
        }


    }
}
