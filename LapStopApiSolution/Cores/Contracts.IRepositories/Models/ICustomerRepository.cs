using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll(bool isTrackChanges);

        Customer? GetById(bool isTrackChanges, Guid id);

        bool IsValidCustomerId(Guid customerId);

        void CreateCustomer(Customer customer);
    }
}
