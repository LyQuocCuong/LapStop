using Contracts.IRepositories.Models;
using Domains.Models;
using DTO.Input.FromQuery.Parameters;
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

        public async Task<IEnumerable<Customer>> GetAllAsync(bool isTrackChanges, CustomerParameters parameters)
        {
            return await FindAll(isTrackChanges)
                            .OrderBy(c => c.FirstName)
                            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                            .Take(parameters.PageSize)
                            .ToListAsync();
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
