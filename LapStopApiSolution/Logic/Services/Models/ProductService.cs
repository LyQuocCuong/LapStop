namespace Services.Models
{
    internal sealed class ProductService : ServiceBase, IProductService
    {
        private readonly IDataShaperService<ProductDto, ExpandoForXmlObject> _dataShaper;

        public ProductService(ILogService logService,
                            IMappingService mappingService,
                            IRepositoryManager repositoryManager,
                            IDataShaperService<ProductDto, ExpandoForXmlObject> dataShaper)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
            _dataShaper = dataShaper;
        }

        private async Task<Product> GetProductAndCheckIfItExists(bool isTrackChanges, Guid productId)
        {
            Product? product = await _repositoryManager.Product.GetOneByIdAsync(isTrackChanges, productId);
            if (product == null)
            {
                throw new ExNotFoundInDBModel(nameof(ProductService), nameof(GetProductAndCheckIfItExists), typeof(Product), productId);
            }
            return product;
        }

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(ProductRequestParam parameters)
        {
            IEnumerable<Product> products = await _repositoryManager.Product.GetAllAsync(isTrackChanges: false, parameters);
            int totalRecords = await _repositoryManager.Product.CountAllAsync(parameters);

            var sourceDto = _mappingService.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

            var shapedData = _dataShaper.Execute(sourceDto, parameters.ShapingProps);

            //return new PagedList<DynamicModel>(shapedData.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);
            return new PagedList<ExpandoForXmlObject>(new List<ExpandoForXmlObject>(), 0, 0, 0);
        }

        public async Task<ProductDto?> GetOneByIdAsync(Guid productId)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: false, productId);
            return _mappingService.Map<Product, ProductDto>(product);
        }

        public async Task<ProductForUpdateDto> GetDtoForPatchAsync(Guid productId)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: false, productId);
            return _mappingService.Map<Product, ProductForUpdateDto>(product);
        }

        public async Task<bool> IsValidIdAsync(Guid productId)
        {
            return await _repositoryManager.Product.IsValidIdAsync(productId);
        }

        public async Task<ProductDto> CreateAsync(ProductForCreationDto creationDto)
        {
            Product newProduct = _mappingService.Map<ProductForCreationDto, Product>(creationDto);
            _repositoryManager.Product.Create(newProduct);
            await _repositoryManager.SaveChangesAsync();

            return _mappingService.Map<Product, ProductDto>(newProduct);
        }

        public async Task UpdateAsync(Guid productId, ProductForUpdateDto updateDto)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: true, productId);
            _mappingService.Map<ProductForUpdateDto, Product>(updateDto, product);
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
            var newProducts = _mappingService.Map<IEnumerable<ProductForCreationDto>, IEnumerable<Product>>(creationDtos);
            await _repositoryManager.Product.BulkCreateAsync(newProducts);

            return _mappingService.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(newProducts);
        }

        public async Task BulkUpdateAsync(IEnumerable<ProductForBulkUpdateDto> bulkUpdateDtos)
        {
            var existingProducts = _mappingService.Map<IEnumerable<ProductForBulkUpdateDto>, IEnumerable<Product>>(bulkUpdateDtos);
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
