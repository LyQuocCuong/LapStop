using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICustomerAccountRepository
    {
        List<CustomerAccount> GetAll(bool isTrackChanges);
        CustomerAccount? GetByCustomerId(bool isTrackChanges, Guid customerId);
    }
}
