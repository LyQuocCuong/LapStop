using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

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
            return MappingToNewObj<List<ProductDto>>(products);
        }

        public ProductDto? GetOneById(bool isTrackChanges, Guid productId)
        {
            Product? product = _repositoryManager.Product.GetOneById(isTrackChanges, productId);
            if (product == null)
            {
                throw new ExNotFoundInDB(nameof(ProductService), nameof(GetOneById), typeof(Product), productId);
            }
            return MappingToNewObj<ProductDto>(product);
        }

        public bool IsValidId(Guid productId)
        {
            return _repositoryManager.Product.IsValidId(productId);
        }
    }
}
