using Repositories.Base;

namespace Repositories.Entities
{
    internal sealed class CustomerRepository : AbstractRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LapStopContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(bool isTrackChanges, CustomerRequestParam parameters)
        {
            return await FindAll(isTrackChanges)
                            .OrderBy(c => c.FirstName)
                            //.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                            //.Take(parameters.PageSize)
                            .Page(parameters.PageNumber, parameters.PageSize)
                            .ToListAsync();
        }

        public async Task<int> CountAllAsync(CustomerRequestParam parameters)
        {
            return await FindAll(isTrackChanges: false)
                            .CountAsync();
        }

        public async Task<Customer?> GetOneByIdAsync(bool isTrackChanges, Guid customerId)
        {
            return await FindByCondition(isTrackChanges, customer => customer.Id == customerId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidIdAsync(Guid customerId)
        {
            return await FindByCondition(isTrackChanges: false, customer => customer.Id == customerId).AnyAsync();
        }

        public void Create(Customer customer)
        {
            base.CreateEntity(customer);
        }

        public void Delete(Customer customer)
        {
            base.DeleteEntity(customer);
        }
    }
}
