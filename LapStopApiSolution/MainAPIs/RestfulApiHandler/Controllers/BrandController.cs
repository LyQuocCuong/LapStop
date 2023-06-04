using Common.Functions;
using Common.Models.DynamicObjects;
using Common.Models.HATEOAS;
using Contracts.ILog;
using Contracts.IServices;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Marvin.Cache.Headers;
using Marvin.Cache.Headers.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RestfulApiHandler.ActionFilters;
using RestfulApiHandler.Roots;
using System.Text.Json;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class BrandController : RootController
    {
        public BrandController(ILogService logService, 
                               IServiceManager serviceManager)
                        : base(logService, serviceManager)
        {
        }

        [HttpHead]
        [Route("brands", Name = "GetAllBrandsHead")]
        public async Task<IActionResult> GetAllBrandsHead([FromQuery]BrandParameters parameters) 
        {
            //PagedList<DynamicModel> pagedResult = await _serviceManager.Brand.GetAllAsync(parameters);

            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));
            
            return Ok();
        }

        [HttpGet]
        [Route("brands", Name = "GetAllBrands")]
        //[ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<IActionResult> GetAllBrands([FromQuery] BrandParameters parameters)
        {
            HateoasParameters<BrandParameters> hateoasParameters = new HateoasParameters<BrandParameters>(HttpContext, parameters);

            PagedList<ExpandoForXmlObject> pagedResult = await _serviceManager.Brand.GetAllAsync(hateoasParameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult);
        }

        [HttpGet]
        [Route("brands/{brandId:guid}", Name = "GetBrandById")]
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        //[HttpCacheValidation(MustRevalidate = true)]
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
        public async Task<IActionResult> CreateBrand([FromServices] IValidator<BrandForCreationDto> creationValidator, 
                                                     [FromBody] BrandForCreationDto creationDto)
        {
            if (creationDto == null)
            {
                return BadRequest(CommonFunctions.DisplayErrors.ReturnNullObjectMessage(nameof(BrandForCreationDto)));
            }

            // apply Validation
            ValidationResult result = await creationValidator.ValidateAsync(creationDto);
            if (result.IsValid == false)
            {
                // Copy the validation results into ModelState.
                // ASP.NET uses the ModelState collection to populate 
                // error messages in the View.
                result.AddToModelState(this.ModelState);

                return UnprocessableEntity(ModelState);
            }

            BrandDto newBrandDto = await _serviceManager.Brand.CreateAsync(creationDto);
            return CreatedAtRoute("GetBrandById", new { brandId = newBrandDto.Id }, newBrandDto);
        }

        [HttpPut]
        [Route("brands/{brandId:guid}", Name = "UpdateBrand")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBrand(Guid brandId, [FromBody] BrandForUpdateDto updateDto,
                                                     [FromServices] IValidatorValueInvalidator validator,
                                                     [FromServices] IStoreKeyAccessor keyAccessor)
        {
            if (await _serviceManager.Brand.IsValidIdAsync(brandId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Brand.UpdateAsync(brandId, updateDto);

            #region MARK FOR INVALIDATION 
            // Mark for Invalidation to remove the out-of-date StoreKey
            string currentUrl = HttpContext!.Request.Path.ToString();
            // Parent URL -
            // CHANGES: localhost:123321/brands/{brandId:guid} ===> localhost:123321/api/brands
            string parentUrl = currentUrl.Replace(string.Concat("/", brandId.ToString()), "");
            IEnumerable<StoreKey> storeKeysOfParentUrl = await keyAccessor.FindByKeyPart(parentUrl);
            ; if (storeKeysOfParentUrl != null)
            {
                await validator.MarkForInvalidation(storeKeysOfParentUrl);
            }
            #endregion

            return NoContent();
        }

        [HttpPatch]
        [Route("brands/{brandId:guid}", Name = "UpdateBrandPartially")]
        public async Task<IActionResult> UpdateBrandPartially(Guid brandId,
                        [FromBody] JsonPatchDocument<BrandForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(CommonFunctions.DisplayErrors.ReturnNullObjectMessage(nameof(JsonPatchDocument<BrandForUpdateDto>)));
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

        [HttpOptions]
        [Route("brands", Name = "GetBrandOptions")]
        public IActionResult GetBrandOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTION, POST, PUT, PATCH, DELETE");

            return Ok();
        }
    }
}
