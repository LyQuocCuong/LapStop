using Contracts.ILog;
using Contracts.IServices;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.ActionFilters;
using Shared.Common.Messages;

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
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameters parameters)
        {
            IEnumerable<ProductDto> productDtos = await _serviceManager.Product.GetAllAsync(parameters);
            return Ok(productDtos);
        }

        [HttpGet]
        [Route("products/{productId:guid}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            ProductDto? productDto = await _serviceManager.Product.GetOneByIdAsync(productId);
            if (productDto == null)
            {
                return NotFound();
            }
            return Ok(productDto);
        }

        [HttpPost]
        [Route("products", Name = "CreateProduct")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody]ProductForCreationDto creationDto)
        {
            ProductDto newProductDto = await _serviceManager.Product.CreateAsync(creationDto);
            return CreatedAtRoute("GetProductById", new { productId = newProductDto.Id }, newProductDto);
        }

        [HttpPut]
        [Route("products/{productId:guid}", Name = "UpdateProduct")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody]ProductForUpdateDto updateDto)
        {
            if (await _serviceManager.Product.IsValidIdAsync(productId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Product.UpdateAsync(productId, updateDto);
            return NoContent();
        }

        [HttpPatch]
        [Route("products/{productId:guid}", Name = "UpdateProductPartially")]
        public async Task<IActionResult> UpdateProductPartially(Guid productId,
                                 JsonPatchDocument<ProductForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest(CommonMessages.ERROR.NullObject(nameof(JsonPatchDocument<ProductForUpdateDto>)));
            }
            if (await _serviceManager.Product.IsValidIdAsync(productId) == false)
            {
                return NotFound();
            }

            // get data from DB
            ProductForUpdateDto updateDto = await _serviceManager.Product.GetDtoForPatchAsync(productId);

            // apply Patch operation + log Errors in ModelState
            patchDocument.ApplyTo(updateDto, ModelState);

            TryValidateModel(updateDto);

            if (ModelState.IsValid == false)
            {
                return UnprocessableEntity(ModelState);
            }

            // update
            await _serviceManager.Product.UpdateAsync(productId, updateDto);

            return NoContent();
        }

        [HttpDelete]
        [Route("products/{productId:guid}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            if (await _serviceManager.Product.IsValidIdAsync(productId) == false)
            {
                return NotFound();
            }
            await _serviceManager.Product.DeleteAsync(productId);
            return NoContent();
        }

    }
}
