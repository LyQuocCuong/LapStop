namespace Contracts.IServices.Entities
{
    public interface IProductService
    {
        Task<PagedList<ExpandoForXmlObject>> GetAllAsync(ProductRequestParam parameters);

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
