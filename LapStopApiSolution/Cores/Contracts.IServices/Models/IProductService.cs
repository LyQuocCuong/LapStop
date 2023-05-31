using Common.Models.DynamicObjects;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;

namespace Contracts.IServices.Models
{
    public interface IProductService
    {
        Task<PagedList<DynamicModel>> GetAllAsync(ProductParameters parameters);

        Task<ProductDto?> GetOneByIdAsync(Guid productId);

        Task<ProductForUpdateDto> GetDtoForPatchAsync(Guid productId);

        Task<bool> IsValidIdAsync(Guid productId);

        Task<ProductDto> CreateAsync(ProductForCreationDto creationDto);

        Task UpdateAsync(Guid productId, ProductForUpdateDto updateDto);

        Task DeleteAsync(Guid productId);

        Task<IEnumerable<ProductDto>> BulkCreateAsync(IEnumerable<ProductForCreationDto> creationDtos);

        Task BulkUpdateAsync(IEnumerable<ProductForBulkUpdateDto> bulkUpdateDtos);

        Task BulkDeleteAsync(IEnumerable<Guid> productIds);
    }
}
