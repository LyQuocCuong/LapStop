using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public ProductController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet("products")]
        public IActionResult GetAll()
        {
            List<ProductDto> productDtos = _serviceManager.Product.GetAll(isTrackChanges: false);
            return Ok(productDtos);
        }

        [HttpGet("products/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            ProductDto? productDto = _serviceManager.Product.GetById(isTrackChanges: false, id);
            if(productDto == null)
            {
                return NotFound();
            }
            return Ok(productDto);
        }

    }
}
