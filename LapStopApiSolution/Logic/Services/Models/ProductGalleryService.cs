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

        public List<ProductGalleryDto> GetAllByProductId(Guid productId)
        {
            if (_repositoryManager.Product.IsValidId(productId) == false) 
            { 
                throw new ExNotFoundInDB(nameof(ProductGalleryService), nameof(GetAllByProductId), typeof(Product), productId);
            }
            List<ProductGallery> productGalleries = _repositoryManager.ProductGallery.GetAllByProductId(isTrackChanges: false, productId);
            return MappingToNewObj<List<ProductGalleryDto>>(productGalleries);
        }
    }
}
