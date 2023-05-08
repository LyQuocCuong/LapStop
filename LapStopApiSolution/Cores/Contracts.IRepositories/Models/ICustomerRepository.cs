using Domains.Models;
using DTO.Parameters;

namespace Contracts.IRepositories.Models
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(bool isTrackChanges, CustomerParameters parameters);

        Task<Customer?> GetOneByIdAsync(bool isTrackChanges, Guid customerId);

        Task<bool> IsValidIdAsync(Guid customerId);

        void Create(Customer customer);
    }
}
