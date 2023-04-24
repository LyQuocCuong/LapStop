using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomedExceptions;

namespace Services.Models
{
    internal sealed class ProductService : ServiceBase, IProductService
    {
        public ProductService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<ProductDto> GetAll(bool isTrackChanges)
        {
            List<Product> products = _repositoryManager.Product.GetAll(isTrackChanges);
            return MappingTo<List<ProductDto>>(products);
        }

        public ProductDto? GetById(bool isTrackChanges, Guid id)
        {
            Product? product = _repositoryManager.Product.GetById(isTrackChanges, id);
            if (product == null)
            {
                throw new NotFoundException404(nameof(ProductService), nameof(GetById), typeof(Product), id);
            }
            return MappingTo<ProductDto>(product);
        }

        public bool IsValidProductId(Guid id)
        {
            return _repositoryManager.Product.IsValidProductId(id);
        }
    }
}
