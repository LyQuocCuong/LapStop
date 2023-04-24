using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class BrandController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public BrandController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("brands")]
        public IActionResult GetAll() 
        {
            List<BrandDto> brandDtos = _serviceManager.Brand.GetAll(isTrackChanges: false);
            return Ok(brandDtos);
        }

        [HttpGet("brands/{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            BrandDto? brandDto = _serviceManager.Brand.GetById(isTrackChanges: false, id);
            if (brandDto == null)
            {
                return NotFound();
            }
            return Ok(brandDto);
        }

    }
}
