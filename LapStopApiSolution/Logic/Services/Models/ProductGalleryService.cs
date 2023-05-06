using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class ProductGalleryService : ServiceBase, IProductGalleryService
    {
        public ProductGalleryService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<ProductGalleryDto>> GetAllByProductIdAsync(Guid productId)
        {
            if (await _repositoryManager.Product.IsValidIdAsync(productId) == false) 
            { 
                throw new ExNotFoundInDB(nameof(ProductGalleryService), nameof(GetAllByProductIdAsync), typeof(Product), productId);
            }
            IEnumerable<ProductGallery> productGalleries = await _repositoryManager.ProductGallery.GetAllByProductIdAsync(isTrackChanges: false, productId);
            return MappingToNewObj<IEnumerable<ProductGalleryDto>>(productGalleries);
        }
    }
}
