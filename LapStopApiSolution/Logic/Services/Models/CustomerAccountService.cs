using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomedExceptions;

namespace Services.Models
{
    internal sealed class CustomerAccountService : ServiceBase, ICustomerAccountService
    {
        public CustomerAccountService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<CustomerAccountDto> GetAll(bool isTrackChanges)
        {
            List<CustomerAccount> customerAccounts = _repositoryManager.CustomerAccount.GetAll(isTrackChanges);
            return MappingTo<List<CustomerAccountDto>>(customerAccounts);
        }

        public CustomerAccountDto? GetByCustomerId(bool isTrackChanges, Guid customerId)
        {
            if (_repositoryManager.Customer.IsValidCustomerId(customerId) == false)
            {
                throw new NotFoundException404(typeof(Customer), nameof(GetByCustomerId), customerId);
            }
            CustomerAccount? customerAccount = _repositoryManager.CustomerAccount.GetByCustomerId(isTrackChanges, customerId);
            if (customerAccount == null)
            {
                throw new NotFoundException404(typeof(CustomerAccount), nameof(GetByCustomerId), customerId);
            }
            return MappingTo<CustomerAccountDto>(customerAccount);
        }
    }
}
