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

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            IEnumerable<Product> products = await _repositoryManager.Product.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetOneByIdAsync(Guid productId)
        {
            Product? product = await _repositoryManager.Product.GetOneByIdAsync(isTrackChanges: false, productId);
            if (product == null)
            {
                throw new ExNotFoundInDB(nameof(ProductService), nameof(GetOneByIdAsync), typeof(Product), productId);
            }
            return MappingToNewObj<ProductDto>(product);
        }

        public async Task<bool> IsValidIdAsync(Guid productId)
        {
            return await _repositoryManager.Product.IsValidIdAsync(productId);
        }
    }
}
