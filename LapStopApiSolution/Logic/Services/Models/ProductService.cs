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

        public ProductDto? GetById(bool isTrackChanges, Guid id)
        {
            Product? product = _repositoryManager.Product.GetById(isTrackChanges, id);
            if (product == null)
            {
                throw new ExNotFoundInDB(nameof(ProductService), nameof(GetById), typeof(Product), id);
            }
            return MappingToNewObj<ProductDto>(product);
        }

        public bool IsValidProductId(Guid id)
        {
            return _repositoryManager.Product.IsValidProductId(id);
        }
    }
}
