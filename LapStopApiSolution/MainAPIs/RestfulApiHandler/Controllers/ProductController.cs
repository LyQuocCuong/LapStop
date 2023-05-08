using Contracts.ILog;
using Contracts.IServices;
using Domains.Models;
using DTO.Output;
using DTO.Parameters;
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

        [HttpGet]
        [Route("products", Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameters parameters)
        {
            IEnumerable<ProductDto> productDtos = await _serviceManager.Product.GetAllAsync(parameters);
            return Ok(productDtos);
        }

        [HttpGet]
        [Route("products/{productId:guid}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            ProductDto? productDto = await _serviceManager.Product.GetOneByIdAsync(productId);
            if(productDto == null)
            {
                return NotFound();
            }
            return Ok(productDto);
        }

    }
}
