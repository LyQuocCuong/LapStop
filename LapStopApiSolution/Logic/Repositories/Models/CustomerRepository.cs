using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(LapStopContext context) : base(context)
        {
        }

        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public List<Customer> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public Customer? GetById(bool isTrackChanges, Guid id)
        {
            return FindByCondition(isTrackChanges, customer => customer.Id == id).FirstOrDefault();
        }

        public bool IsValidCustomerId(Guid customerId)
        {
            return FindByCondition(isTrackChanges: false, customer => customer.Id == customerId).Any();
        }
    }
}
