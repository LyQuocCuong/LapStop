using Contracts.ILog;
using Contracts.IServices;
using DTO.Creation;
using DTO.Output;
using DTO.Update;
using Microsoft.AspNetCore.Mvc;
using Shared.Common.Messages;

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

        [HttpPost]
        [Route("brands")]
        public IActionResult CreateBrand([FromBody] BrandForCreationDto creationDto)
        {
            if (creationDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(BrandForCreationDto)));
            }
            BrandDto newBrandDto = _serviceManager.Brand.CreateBrand(creationDto);
            return CreatedAtRoute("GetBrandById", new { id = newBrandDto.Id }, newBrandDto);
        }

        [HttpGet]
        [Route("brands/{id:guid}", Name = "GetBrandById")]
        public IActionResult GetById(Guid id)
        {
            BrandDto? brandDto = _serviceManager.Brand.GetById(isTrackChanges: false, id);
            if (brandDto == null)
            {
                return NotFound();
            }
            return Ok(brandDto);
        }

        [HttpDelete]
        [Route("brands/{id:guid}")]
        public IActionResult DeleteBrand(Guid id)
        {
            _serviceManager.Brand.DeleteBrand(id);
            return NoContent();
        }

        [HttpPut]
        [Route("brands/{id:guid}")]
        public IActionResult UpdateBrand(Guid id, [FromBody] BrandForUpdateDto updateDto)
        {
            _serviceManager.Brand.UpdateBrand(id, updateDto);
            return NoContent();
        }

    }
}
