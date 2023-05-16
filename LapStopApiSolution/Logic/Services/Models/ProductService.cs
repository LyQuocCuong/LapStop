using AutoMapper;
using Contracts.IDataShaper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using Shared.CustomModels.DynamicObjects;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class ProductService : ServiceBase, IProductService
    {
        private readonly IDataShaper<ProductDto> _dataShaper;

        public ProductService(IRepositoryManager repositoryManager, 
                              IMapper mapper,
                              IDataShaper<ProductDto> dataShaper) : base(repositoryManager, mapper)
        {
            _dataShaper = dataShaper;
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

        public async Task<PagedList<ShapedModel>> GetAllAsync(ProductParameters parameters)
        {
            IEnumerable<Product> products = await _repositoryManager.Product.GetAllAsync(isTrackChanges: false, parameters);
            int totalRecords = await _repositoryManager.Product.CountAllAsync(parameters);

            var sourceDto = MappingToNewObj<IEnumerable<ProductDto>>(products);

            var shapedData = _dataShaper.ShapeData(sourceDto, parameters.Fields);

            return new PagedList<ShapedModel>(shapedData.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);
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

        public async Task<IEnumerable<ProductDto>> BulkCreateAsync(IEnumerable<ProductForCreationDto> creationDtos)
        {
            var newProducts = MappingToNewObj<IEnumerable<Product>>(creationDtos);
            await _repositoryManager.Product.BulkCreateAsync(newProducts);

            return MappingToNewObj<IEnumerable<ProductDto>>(newProducts);
        }

        public async Task BulkUpdateAsync(IEnumerable<ProductForBulkUpdateDto> bulkUpdateDtos)
        {
            var existingProducts = MappingToNewObj<IEnumerable<Product>>(bulkUpdateDtos);
            await _repositoryManager.Product.BulkUpdateAsync(existingProducts);
        }

        public async Task BulkDeleteAsync(IEnumerable<Guid> productIds)
        {
            List<Product> productList = new List<Product>();
            foreach(Guid id in productIds)
            {
                Product? product = await _repositoryManager.Product.GetOneByIdAsync(isTrackChanges: true, id);
                if (product != null)
                {
                    productList.Add(product);
                }
            }
            await _repositoryManager.Product.BulkDeleteAsync(productList);
        }
    }
}
