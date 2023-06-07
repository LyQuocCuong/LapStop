namespace Repositories.Models
{
    internal sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(LapStopContext context) : base(context)
        {
        }
                
        public async Task<IEnumerable<Product>> GetAllAsync(bool isTrackChanges, ProductRequestParam parameters)
        {
            return await FindAll(isTrackChanges)
                            .OrderBy(p => p.Name)
                            //.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                            //.Take(parameters.PageSize)
                            .Page(parameters.PageNumber, parameters.PageSize)
                            .ToListAsync();
        }

        public async Task<int> CountAllAsync(ProductRequestParam parameters)
        {
            return await FindAll(isTrackChanges: false)
                            .CountAsync();
        }

        public async Task<Product?> GetOneByIdAsync(bool isTrackChanges, Guid productId)
        {
            return await FindByCondition(isTrackChanges, e => e.Id == productId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidIdAsync(Guid productId)
        {
            return await FindByCondition(isTrackChanges: false, e => e.Id == productId).AnyAsync();
        }

        public void Create(Product product)
        {
            base.CreateModel(product);
        }

        public void Delete(Product product)
        {
            base.DeleteModel(product);
        }

        public async Task BulkCreateAsync(IEnumerable<Product> products)
        {
            await _context.BulkInsertAsync(products, options =>
            {
                options.InsertIfNotExists = true;
            });
        }

        public async Task BulkUpdateAsync(IEnumerable<Product> products)
        {
            // if having Tracking, can use BulkSaveChangesAsync() 
            await _context.BulkUpdateAsync(products);
        }

        public async Task BulkDeleteAsync(IEnumerable<Product> products)
        {
            foreach(var product in products)
            {
                product.IsRemoved = true;
            }
            await _context.BulkUpdateAsync(products);
        }

    }
}
