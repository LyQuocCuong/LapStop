using Contracts.ILog;
using Contracts.IServices;
using Domains.Models;
using DTO.Creation;
using DTO.Output;
using DTO.Update;
using Microsoft.AspNetCore.JsonPatch;
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
        [Route("brands", Name = "GetAllBrands")]
        public IActionResult GetAllBrands() 
        {
            List<BrandDto> brandDtos = _serviceManager.Brand.GetAll();
            return Ok(brandDtos);
        }

        [HttpGet]
        [Route("brands/{brandId:guid}", Name = "GetBrandById")]
        public IActionResult GetBrandById(Guid brandId)
        {
            BrandDto? brandDto = _serviceManager.Brand.GetOneById(brandId);
            if (brandDto == null)
            {
                return NotFound();
            }
            return Ok(brandDto);
        }

        [HttpPost]
        [Route("brands", Name = "CreateBrand")]
        public IActionResult CreateBrand([FromBody] BrandForCreationDto creationDto)
        {
            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }
            if (creationDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(BrandForCreationDto)));
            }
            BrandDto newBrandDto = _serviceManager.Brand.Create(creationDto);
            return CreatedAtRoute("GetBrandById", new { brandId = newBrandDto.Id }, newBrandDto);
        }

        [HttpDelete]
        [Route("brands/{brandId:guid}", Name = "DeleteBrand")]
        public IActionResult DeleteBrand(Guid brandId)
        {
            if (_serviceManager.Brand.IsValidId(brandId) == false)
            {
                return NotFound();
            }
            _serviceManager.Brand.Delete(brandId);
            return NoContent();
        }

        [HttpPut]
        [Route("brands/{brandId:guid}", Name = "UpdateBrand")]
        public IActionResult UpdateBrand(Guid brandId, [FromBody] BrandForUpdateDto updateDto)
        {
            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }
            if (updateDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(BrandForUpdateDto)));
            }
            if (_serviceManager.Brand.IsValidId(brandId) == false)
            {
                return NotFound();
            }
            _serviceManager.Brand.Update(brandId, updateDto);
            return NoContent();
        }

        [HttpPatch]
        [Route("brands/{brandId:guid}", Name = "UpdateBrandPartially")]
        public IActionResult UpdateBrandPartially(Guid brandId,
                        [FromBody] JsonPatchDocument<BrandForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(JsonPatchDocument<BrandForUpdateDto>)));
            }
            else if (_serviceManager.Brand.IsValidId(brandId) == false)
            {
                return NotFound();
            }
            // get data from DB
            BrandForUpdateDto updateDto = _serviceManager.Brand.GetDtoForPatch(brandId);
            // apply Patch operation
            patchDocument.ApplyTo(updateDto);
            // update
            _serviceManager.Brand.Update(brandId, updateDto);

            return NoContent();
        }

    }
}
