using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class ProductService : ServiceBase, IProductService
    {
        public ProductService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        private async Task<Product> GetProductAndCheckIfItExists(bool isTrackChanges, Guid productId)
        {
            Product? product = await _repositoryManager.Product.GetOneByIdAsync(isTrackChanges, productId);
            if (product == null)
            {
                throw new ExNotFoundInDB(nameof(ProductService), nameof(GetProductAndCheckIfItExists), typeof(Product), productId);
            }
            return product;
        }

        public async Task<PagedList<ProductDto>> GetAllAsync(ProductParameters parameters)
        {
            IEnumerable<Product> products = await _repositoryManager.Product.GetAllAsync(isTrackChanges: false, parameters);
            int totalRecords = await _repositoryManager.Product.CountAllAsync(parameters);

            var sourceDto = MappingToNewObj<IEnumerable<ProductDto>>(products);
            return new PagedList<ProductDto>(sourceDto.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<ProductDto?> GetOneByIdAsync(Guid productId)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: false, productId);
            return MappingToNewObj<ProductDto>(product);
        }

        public async Task<ProductForUpdateDto> GetDtoForPatchAsync(Guid productId)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: false, productId);
            return MappingToNewObj<ProductForUpdateDto>(product);
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
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: true, productId);
            MappingToExistingObj(updateDto, product);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid productId)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: true, productId);
            _repositoryManager.Product.Delete(product);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
