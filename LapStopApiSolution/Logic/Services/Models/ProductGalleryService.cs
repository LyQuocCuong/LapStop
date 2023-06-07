namespace Services.Models
{
    internal sealed class ProductGalleryService : ServiceBase, IProductGalleryService
    {
        public ProductGalleryService(ILogService logService,
                               IMappingService mappingService,
                               IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<IEnumerable<ProductGalleryDto>> GetAllByProductIdAsync(Guid productId)
        {
            if (await _repositoryManager.Product.IsValidIdAsync(productId) == false) 
            { 
                throw new ExNotFoundInDBModel(nameof(ProductGalleryService), nameof(GetAllByProductIdAsync), typeof(Product), productId);
            }
            IEnumerable<ProductGallery> productGalleries = await _repositoryManager.ProductGallery.GetAllByProductIdAsync(isTrackChanges: false, productId);
            return _mappingService.Map<IEnumerable<ProductGallery>, IEnumerable<ProductGalleryDto>>(productGalleries);
        }
    }
}
