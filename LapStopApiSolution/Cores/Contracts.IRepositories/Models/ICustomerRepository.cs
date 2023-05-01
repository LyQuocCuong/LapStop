using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll(bool isTrackChanges);

        Customer? GetOneById(bool isTrackChanges, Guid customerId);

        bool IsValidId(Guid customerId);

        void Create(Customer customer);
    }
}
