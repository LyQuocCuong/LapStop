namespace Contracts.IRepositories.Entities
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(bool isTrackChanges, CustomerRequestParam parameters);

        Task<Customer?> GetOneByIdAsync(bool isTrackChanges, Guid customerId);

        Task<bool> IsValidIdAsync(Guid customerId);

        Task<int> CountAllAsync(CustomerRequestParam parameters);

        void Create(Customer customer);

        void Delete(Customer customer);
    }
}
