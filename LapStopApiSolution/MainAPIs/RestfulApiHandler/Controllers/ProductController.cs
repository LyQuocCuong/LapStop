using Common.Functions;
using Common.Models.DynamicObjects;
using Contracts.ILog;
using Contracts.IServices;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestfulApiHandler.ActionFilters;
using RestfulApiHandler.Roots;
using System.Text.Json;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProductController : RootController
    {
        public ProductController(ILogService logService, 
                                 IServiceManager serviceManager)
                           :base(logService, serviceManager)
        {
        }

        [HttpHead]
        [Route("products", Name = "GetAllProductsHead")]
        public async Task<IActionResult> GetAllProductsHead([FromQuery] ProductParameters parameters)
        {
            PagedList<DynamicModel> pagedResult = await _serviceManager.Product.GetAllAsync(parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok();
        }

        [HttpGet]
        [Route("products", Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParameters parameters)
        {
            PagedList<DynamicModel> pagedResult = await _serviceManager.Product.GetAllAsync(parameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

            return Ok(pagedResult);
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
                return BadRequest(CommonFunctions.DisplayErrors.ReturnNullObjectMessage(nameof(JsonPatchDocument<ProductForUpdateDto>)));
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

        [HttpOptions]
        [Route("products", Name = "GetProductOptions")]
        public IActionResult GetProductOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, PATCH");
            return Ok();
        }

        private static IEnumerable<ProductDto> productDtos;

        [HttpPost]
        [Route("products/bulk", Name = "BulkCreateProduct")]
        public async Task<IActionResult> BulkCreateProduct()
        {
            //List<ProductForCreationDto> data = new List<ProductForCreationDto>();
            //for (int index = 0; index < 1000; index++)
            //{
            //    ProductForCreationDto product = new ProductForCreationDto()
            //    {
            //        ProductStatusId = CommonSeedingData.Product_Status.IN_STOCK.Id,
            //        ProductCode = "AD0" + index,
            //        Name = "Adidas " + index,
            //        OriginalPrice = 1000 + index,
            //        SellingPrice = 1000 + index,
            //        CurrentPrice = 1000 + index,
            //    };
            //    data.Add(product);
            //}
            //productDtos = await _serviceManager.Product.BulkCreateAsync(data);
            return Ok();
        }

        [HttpPut]
        [Route("products/bulk", Name = "BulkUpdateProduct")]
        public async Task<IActionResult> BulkUpdateProduct()
        {
            List<ProductForBulkUpdateDto> bulkUpdateDtos = new List<ProductForBulkUpdateDto>();
            foreach(var product in productDtos)
            {
                bulkUpdateDtos.Add(new ProductForBulkUpdateDto()
                {
                    Id = product.Id,
                    ProductStatusId = product.ProductStatusId,
                    ProductCode = product.ProductCode + "EDITED",
                    Name = product.Name,
                    OriginalPrice = product.OriginalPrice,
                    SellingPrice = product.SellingPrice,
                    CurrentPrice = product.CurrentPrice
                });
            }
            await _serviceManager.Product.BulkUpdateAsync(bulkUpdateDtos);
            return NoContent();
        }

        [HttpDelete]
        [Route("products/bulk", Name = "BulkDeleteProduct")]
        public async Task<IActionResult> BulkDeleteProduct()
        {
            List<Guid> ids = productDtos.Select(p => p.Id).ToList();
            await _serviceManager.Product.BulkDeleteAsync(ids);
            return NoContent();
        }

    }
}
