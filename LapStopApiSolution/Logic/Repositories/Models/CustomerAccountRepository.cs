namespace Repositories.Models
{
    internal sealed class CustomerAccountRepository : RepositoryBase<CustomerAccount>, ICustomerAccountRepository
    {
        public CustomerAccountRepository(LapStopContext context) : base(context)
        {
        }

        public void Create(CustomerAccount customerAccount)
        {
            base.CreateModel(customerAccount);
        }

        public async Task<IEnumerable<CustomerAccount>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<CustomerAccount?> GetOneByCustomerIdAsync(bool isTrackChanges, Guid customerId)
        {
            return await FindByCondition(isTrackChanges, customerAcc => customerAcc.CustomerId == customerId).FirstOrDefaultAsync();
        }
    }
}
