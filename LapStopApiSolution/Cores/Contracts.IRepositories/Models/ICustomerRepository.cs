using Domains.Models;
using DTO.Input.FromQuery.Parameters;

namespace Contracts.IRepositories.Models
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(bool isTrackChanges, CustomerParameters parameters);

        Task<Customer?> GetOneByIdAsync(bool isTrackChanges, Guid customerId);

        Task<bool> IsValidIdAsync(Guid customerId);

        Task<int> CountAllAsync(CustomerParameters parameters);

        void Create(Customer customer);

        void Delete(Customer customer);
    }
}
