using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Customer>> GetAllAsync(bool isTrackChanges)
        {
            return await FindAll(isTrackChanges).ToListAsync();
        }

        public async Task<Customer?> GetOneByIdAsync(bool isTrackChanges, Guid customerId)
        {
            return await FindByCondition(isTrackChanges, customer => customer.Id == customerId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidIdAsync(Guid customerId)
        {
            return await FindByCondition(isTrackChanges: false, customer => customer.Id == customerId).AnyAsync();
        }
    }
}
