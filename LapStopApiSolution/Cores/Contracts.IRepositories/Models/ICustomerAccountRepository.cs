using Domains.Models;

namespace Contracts.IRepositories.Models
{
    public interface ICustomerAccountRepository
    {
        List<CustomerAccount> GetAll(bool isTrackChanges);
        CustomerAccount? GetById(bool isTrackChanges, Guid id);
    }
}
