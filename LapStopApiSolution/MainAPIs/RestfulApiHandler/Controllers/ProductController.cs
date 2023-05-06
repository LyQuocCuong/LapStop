using Contracts.ILog;
using Contracts.IServices;
using Domains.Models;
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

        [HttpGet]
        [Route("products", Name = "GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            IEnumerable<ProductDto> productDtos = _serviceManager.Product.GetAll();
            return Ok(productDtos);
        }

        [HttpGet]
        [Route("products/{productId:guid}", Name = "GetProductById")]
        public IActionResult GetProductById(Guid productId)
        {
            ProductDto? productDto = _serviceManager.Product.GetOneById(productId);
            if(productDto == null)
            {
                return NotFound();
            }
            return Ok(productDto);
        }

    }
}
