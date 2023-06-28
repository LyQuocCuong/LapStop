namespace Services.Entities
{
    internal sealed class ProductStatusService : AbstractService, IProductStatusService
    {
        public ProductStatusService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        public async Task<IEnumerable<ProductStatusDto>> GetAllAsync()
        {
            IEnumerable<ProductStatus> productStatuses = await EntityRepositories.ProductStatus.GetAllAsync(isTrackChanges: false);
            return UtilityServices.Mapper.ExecuteMapping<IEnumerable<ProductStatus>, IEnumerable<ProductStatusDto>>(productStatuses);
        }

        public async Task<ProductStatusDto?> GetOneByIdAsync(Guid productStatusId)
        {
            ProductStatus? productStatus = await EntityRepositories.ProductStatus.GetOneByIdAsync(isTrackChanges: false, productStatusId);
            if (productStatus == null)
            {
                throw new ExNotFoundInDBModel(nameof(ProductStatusService), nameof(GetOneByIdAsync), typeof(ProductStatus), productStatusId);
            }
            return UtilityServices.Mapper.ExecuteMapping<ProductStatus, ProductStatusDto>(productStatus);
        }
    }
}
