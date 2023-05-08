﻿using Contracts.ILog;
using Contracts.IServices;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
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
        public async Task<IActionResult> GetAllBrands([FromQuery]BrandParameters parameters) 
        {
            IEnumerable<BrandDto> brandDtos = await _serviceManager.Brand.GetAllAsync(parameters);
            return Ok(brandDtos);
        }

        [HttpGet]
        [Route("brands/{brandId:guid}", Name = "GetBrandById")]
        public async Task<IActionResult> GetBrandById(Guid brandId)
        {
            BrandDto? brandDto = await _serviceManager.Brand.GetOneByIdAsync(brandId);
            if (brandDto == null)
            {
                return NotFound();
            }
            return Ok(brandDto);
        }

        [HttpPost]
        [Route("brands", Name = "CreateBrand")]
        public async Task<IActionResult> CreateBrand([FromBody] BrandForCreationDto creationDto)
        {
            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }
            if (creationDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(BrandForCreationDto)));
            }
            BrandDto newBrandDto = await _serviceManager.Brand.CreateAsync(creationDto);
            return CreatedAtRoute("GetBrandById", new { brandId = newBrandDto.Id }, newBrandDto);
        }

        [HttpDelete]
        [Route("brands/{brandId:guid}", Name = "DeleteBrand")]
        public async Task<IActionResult> DeleteBrand(Guid brandId)
        {
            if (await _serviceManager.Brand.IsValidIdAsync(brandId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Brand.DeleteAsync(brandId);
            return NoContent();
        }

        [HttpPut]
        [Route("brands/{brandId:guid}", Name = "UpdateBrand")]
        public async Task<IActionResult> UpdateBrand(Guid brandId, [FromBody] BrandForUpdateDto updateDto)
        {
            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }
            if (updateDto == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(BrandForUpdateDto)));
            }
            if (await _serviceManager.Brand.IsValidIdAsync(brandId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Brand.UpdateAsync(brandId, updateDto);
            return NoContent();
        }

        [HttpPatch]
        [Route("brands/{brandId:guid}", Name = "UpdateBrandPartially")]
        public async Task<IActionResult> UpdateBrandPartially(Guid brandId,
                        [FromBody] JsonPatchDocument<BrandForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(JsonPatchDocument<BrandForUpdateDto>)));
            }
            else if (await _serviceManager.Brand.IsValidIdAsync(brandId) == false)
            {
                return NotFound();
            }
            // get data from DB
            BrandForUpdateDto updateDto = await _serviceManager.Brand.GetDtoForPatchAsync(brandId);

            // apply Patch operation + log Errors in ModelState
            patchDocument.ApplyTo(updateDto, ModelState);

            TryValidateModel(updateDto);

            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }

            // update
            await _serviceManager.Brand.UpdateAsync(brandId, updateDto);

            return NoContent();
        }

    }
}
