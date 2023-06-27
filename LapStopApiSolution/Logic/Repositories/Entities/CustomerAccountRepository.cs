namespace Repositories.Entities
{
    internal sealed class CustomerAccountRepository : AbstractEntityRepository<CustomerAccount>, ICustomerAccountRepository
    {
        public CustomerAccountRepository(EntityRepositoryParams repoParams) : base(repoParams)
        {
        }

        public void Create(CustomerAccount customerAccount)
        {
            base.CreateEntity(customerAccount);
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
