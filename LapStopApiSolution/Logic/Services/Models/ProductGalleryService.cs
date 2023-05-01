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

        public List<ProductGalleryDto> GetByProductId(bool isTrackChanges, Guid id)
        {
            if (_repositoryManager.Product.IsValidProductId(id) == false) 
            { 
                throw new ExNotFoundInDB(nameof(ProductGalleryService), nameof(GetByProductId), typeof(Product), id);
            }
            List<ProductGallery> productGalleries = _repositoryManager.ProductGallery.GetByProductId(isTrackChanges, id);
            return MappingToNewObj<List<ProductGalleryDto>>(productGalleries);
        }
    }
}
