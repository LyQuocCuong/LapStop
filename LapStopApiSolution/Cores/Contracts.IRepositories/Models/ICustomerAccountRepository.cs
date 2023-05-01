using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICustomerAccountRepository
    {
        List<CustomerAccount> GetAll(bool isTrackChanges);

        CustomerAccount? GetOneByCustomerId(bool isTrackChanges, Guid customerId);

        void Create(CustomerAccount customerAccount);
    }
}
