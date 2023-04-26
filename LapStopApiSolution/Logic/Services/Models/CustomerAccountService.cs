using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Creation;
using DTO.Output;
using DTO.Update;
using Shared.CustomedExceptions;

namespace Services.Models
{
    internal sealed class CustomerAccountService : ServiceBase, ICustomerAccountService
    {
        public CustomerAccountService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public CustomerAccountDto CreateCustomerAccount(Guid customerId, CustomerAccountForCreationDto creationDto)
        {
            CustomerAccount newCustomerAccount = MappingToNewObj<CustomerAccount> (creationDto);
            newCustomerAccount.CustomerId = customerId;
            _repositoryManager.CustomerAccount.CreateCustomerAccount(newCustomerAccount);
            _repositoryManager.SaveChanges();

            return MappingToNewObj<CustomerAccountDto>(newCustomerAccount);
        }

        public void UpdateCustomerAccount(Guid customerId, CustomerAccountForUpdateDto updateDto)
        {
            CustomerAccount? customerAccount = _repositoryManager.CustomerAccount.GetByCustomerId(isTrackChanges: true, customerId);
            if (customerAccount == null)
            {
                throw new NotFoundException404(nameof(CustomerAccountService), nameof(UpdateCustomerAccount), typeof(CustomerAccount), customerId);
            }
            MappingToExistingObj(updateDto, customerAccount);
            _repositoryManager.SaveChanges();
        }

        public List<CustomerAccountDto> GetAll(bool isTrackChanges)
        {
            List<CustomerAccount> customerAccounts = _repositoryManager.CustomerAccount.GetAll(isTrackChanges);
            return MappingToNewObj<List<CustomerAccountDto>>(customerAccounts);
        }

        public CustomerAccountDto? GetByCustomerId(bool isTrackChanges, Guid customerId)
        {
            if (_repositoryManager.Customer.IsValidCustomerId(customerId) == false)
            {
                throw new NotFoundException404(nameof(CustomerAccountService), nameof(GetByCustomerId), typeof(Customer), customerId);
            }
            CustomerAccount? customerAccount = _repositoryManager.CustomerAccount.GetByCustomerId(isTrackChanges, customerId);
            if (customerAccount == null)
            {
                throw new NotFoundException404(nameof(CustomerAccountService), nameof(GetByCustomerId), typeof(CustomerAccount), customerId);
            }
            return MappingToNewObj<CustomerAccountDto>(customerAccount);
        }

    }
}
