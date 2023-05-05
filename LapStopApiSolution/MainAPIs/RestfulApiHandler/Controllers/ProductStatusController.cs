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
        public IActionResult GetAllProductStatuses()
        {
            List<ProductStatusDto> productStatusDtos = _serviceManager.ProductStatus.GetAll();
            return Ok(productStatusDtos);
        }

        [HttpGet]
        [Route("productstatuses/{productStatusId:guid}", Name = "GetProductStatusById")]
        public IActionResult GetProductStatusById(Guid productStatusId)
        {
            ProductStatusDto? productStatusDto = _serviceManager.ProductStatus.GetOneById(productStatusId);
            if (productStatusDto == null)
            {
                return NotFound();
            }
            return Ok(productStatusDto);
        }

    }
}
