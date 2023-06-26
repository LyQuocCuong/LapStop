namespace Contracts.IRepositories.Entities
{
    public interface ICustomerAccountRepository
    {
        Task<IEnumerable<CustomerAccount>> GetAllAsync(bool isTrackChanges);

        Task<CustomerAccount?> GetOneByCustomerIdAsync(bool isTrackChanges, Guid customerId);

        void Create(CustomerAccount customerAccount);
    }
}
