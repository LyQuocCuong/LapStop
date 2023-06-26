namespace Services.Entities
{
    internal sealed class ProductGalleryService : AbstractService, IProductGalleryService
    {
        public ProductGalleryService(IDomainRepositories domainRepository,
                            IUtilityServices utilityServices)
            : base(domainRepository, utilityServices)
        {
        }

        public async Task<IEnumerable<ProductGalleryDto>> GetAllByProductIdAsync(Guid productId)
        {
            if (await EntityRepositories.Product.IsValidIdAsync(productId) == false) 
            { 
                throw new ExNotFoundInDBModel(nameof(ProductGalleryService), nameof(GetAllByProductIdAsync), typeof(Product), productId);
            }
            IEnumerable<ProductGallery> productGalleries = await EntityRepositories.ProductGallery.GetAllByProductIdAsync(isTrackChanges: false, productId);
            return UtilServices.Mapper.ExecuteMapping<IEnumerable<ProductGallery>, IEnumerable<ProductGalleryDto>>(productGalleries);
        }
    }
}
