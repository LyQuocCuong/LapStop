using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.Roots;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductStatusController : RootController
    {
        public ProductStatusController(ILogService logService, 
                                       IServiceManager serviceManager)
                                : base(logService, serviceManager)
        {
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
