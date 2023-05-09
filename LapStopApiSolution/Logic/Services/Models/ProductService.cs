using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class ProductService : ServiceBase, IProductService
    {
        public ProductService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync(ProductParameters parameters)
        {
            IEnumerable<Product> products = await _repositoryManager.Product.GetAllAsync(isTrackChanges: false, parameters);
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


        public async Task<ProductDto> CreateAsync(ProductForCreationDto creationDto)
        {
            Product newProduct = MappingToNewObj<Product>(creationDto);
            _repositoryManager.Product.Create(newProduct);
            await _repositoryManager.SaveChangesAsync();

            return MappingToNewObj<ProductDto>(newProduct);
        }

        public async Task UpdateAsync(Guid productId, ProductForUpdateDto updateDto)
        {
            Product? product = await _repositoryManager.Product.GetOneByIdAsync(isTrackChanges: true, productId);
            if (product == null)
            {
                throw new ExNotFoundInDB(nameof(ProductService), nameof(UpdateAsync), typeof(Product), productId);  
            }
            MappingToExistingObj(updateDto, product);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid productId)
        {
            Product? product = await _repositoryManager.Product.GetOneByIdAsync(isTrackChanges: true, productId);
            if (product == null)
            {
                throw new ExNotFoundInDB(nameof(ProductService), nameof(DeleteAsync), typeof(Product), productId);
            }
            _repositoryManager.Product.Delete(product);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
