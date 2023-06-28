namespace Services.Entities
{
    internal sealed class ProductService : AbstractService, IProductService
    {
        public ProductService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        private async Task<Product> GetProductAndCheckIfItExists(bool isTrackChanges, Guid productId)
        {
            Product? product = await EntityRepositories.Product.GetOneByIdAsync(isTrackChanges, productId);
            if (product == null)
            {
                throw new ExNotFoundInDBModel(nameof(ProductService), nameof(GetProductAndCheckIfItExists), typeof(Product), productId);
            }
            return product;
        }

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(ProductRequestParam parameters)
        {
            IEnumerable<Product> products = await EntityRepositories.Product.GetAllAsync(isTrackChanges: false, parameters);
            int totalRecords = await EntityRepositories.Product.CountAllAsync(parameters);

            var sourceDto = UtilityServices.Mapper.ExecuteMapping<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

            var shapedData = UtilityServices.DataShaperForProduct.Execute(sourceDto, parameters.ShapingProps);

            //return new PagedList<DynamicModel>(shapedData.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);
            return new PagedList<ExpandoForXmlObject>(new List<ExpandoForXmlObject>(), 0, 0, 0);
        }

        public async Task<ProductDto?> GetOneByIdAsync(Guid productId)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: false, productId);
            return UtilityServices.Mapper.ExecuteMapping<Product, ProductDto>(product);
        }

        public async Task<ProductForUpdateDto> GetDtoForPatchAsync(Guid productId)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: false, productId);
            return UtilityServices.Mapper.ExecuteMapping<Product, ProductForUpdateDto>(product);
        }

        public async Task<bool> IsValidIdAsync(Guid productId)
        {
            return await EntityRepositories.Product.IsValidIdAsync(productId);
        }

        public async Task<ProductDto> CreateAsync(ProductForCreationDto creationDto)
        {
            Product newProduct = UtilityServices.Mapper.ExecuteMapping<ProductForCreationDto, Product>(creationDto);
            EntityRepositories.Product.Create(newProduct);
            await SaveChangesToDatabaseAsync();

            return UtilityServices.Mapper.ExecuteMapping<Product, ProductDto>(newProduct);
        }

        public async Task UpdateAsync(Guid productId, ProductForUpdateDto updateDto)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: true, productId);
            UtilityServices.Mapper.ExecuteMapping<ProductForUpdateDto, Product>(updateDto, product);
            await SaveChangesToDatabaseAsync();
        }

        public async Task DeleteAsync(Guid productId)
        {
            Product product = await GetProductAndCheckIfItExists(isTrackChanges: true, productId);
            EntityRepositories.Product.Delete(product);
            await SaveChangesToDatabaseAsync();
        }

        public async Task<IEnumerable<ProductDto>> BulkCreateAsync(IEnumerable<ProductForCreationDto> creationDtos)
        {
            var newProducts = UtilityServices.Mapper.ExecuteMapping<IEnumerable<ProductForCreationDto>, IEnumerable<Product>>(creationDtos);
            await EntityRepositories.Product.BulkCreateAsync(newProducts);

            return UtilityServices.Mapper.ExecuteMapping<IEnumerable<Product>, IEnumerable<ProductDto>>(newProducts);
        }

        public async Task BulkUpdateAsync(IEnumerable<ProductForBulkUpdateDto> bulkUpdateDtos)
        {
            var existingProducts = UtilityServices.Mapper.ExecuteMapping<IEnumerable<ProductForBulkUpdateDto>, IEnumerable<Product>>(bulkUpdateDtos);
            await EntityRepositories.Product.BulkUpdateAsync(existingProducts);
        }

        public async Task BulkDeleteAsync(IEnumerable<Guid> productIds)
        {
            List<Product> productList = new List<Product>();
            foreach(Guid id in productIds)
            {
                Product? product = await EntityRepositories.Product.GetOneByIdAsync(isTrackChanges: true, id);
                if (product != null)
                {
                    productList.Add(product);
                }
            }
            await EntityRepositories.Product.BulkDeleteAsync(productList);
        }
    }
}
