using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(bool isTrackChanges);

        Task<Customer?> GetOneByIdAsync(bool isTrackChanges, Guid customerId);

        Task<bool> IsValidIdAsync(Guid customerId);

        void Create(Customer customer);
    }
}
