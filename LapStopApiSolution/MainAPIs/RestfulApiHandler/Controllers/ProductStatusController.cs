using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductStatusController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public ProductStatusController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("productstatuses", Name = "GetAllProductStatuses")]
        public async Task<IActionResult> GetAllProductStatuses()
        {
            IEnumerable<ProductStatusDto> productStatusDtos = await _serviceManager.ProductStatus.GetAllAsync();
            return Ok(productStatusDtos);
        }

        [HttpGet]
        [Route("productstatuses/{productStatusId:guid}", Name = "GetProductStatusById")]
        public async Task<IActionResult> GetProductStatusById(Guid productStatusId)
        {
            ProductStatusDto? productStatusDto = await _serviceManager.ProductStatus.GetOneByIdAsync(productStatusId);
            if (productStatusDto == null)
            {
                return NotFound();
            }
            return Ok(productStatusDto);
        }

    }
}
