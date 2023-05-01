using Contracts.IRepositories.Models;
using Domains.Models;
using Entities.Context;

namespace Repositories.Models
{
    internal sealed class CustomerAccountRepository : RepositoryBase<CustomerAccount>, ICustomerAccountRepository
    {
        public CustomerAccountRepository(LapStopContext context) : base(context)
        {
        }

        public void Create(CustomerAccount customerAccount)
        {
            base.CreateModel(customerAccount);
        }

        public List<CustomerAccount> GetAll(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }

        public CustomerAccount? GetOneByCustomerId(bool isTrackChanges, Guid customerId)
        {
            return FindByCondition(isTrackChanges, customerAcc => customerAcc.CustomerId == customerId).FirstOrDefault();
        }
    }
}
