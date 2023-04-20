using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api/productstatuses")]
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
        public IActionResult GetAll()
        {
            List<ProductStatusDto> productStatusDtos = _serviceManager.ProductStatus.GetAll(isTrackChanges: false);
            return Ok(productStatusDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            ProductStatusDto? productStatusDto = _serviceManager.ProductStatus.GetById(isTrackChanges: false, id);
            if (productStatusDto == null)
            {
                return NotFound();
            }
            return Ok(productStatusDto);
        }

    }
}
