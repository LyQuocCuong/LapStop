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

        public void Create(Customer customer)
        {
            base.CreateModel(customer);
        }

        public IEnumerable<Customer> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges);
        }

        public Customer? GetOneById(bool isTrackChanges, Guid customerId)
        {
            return FindByCondition(isTrackChanges, customer => customer.Id == customerId).FirstOrDefault();
        }

        public bool IsValidId(Guid customerId)
        {
            return FindByCondition(isTrackChanges: false, customer => customer.Id == customerId).Any();
        }
    }
}
