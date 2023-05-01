using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Creation;
using DTO.Output;
using DTO.Update;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class CustomerAccountService : ServiceBase, ICustomerAccountService
    {
        public CustomerAccountService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public CustomerAccountDto Create(Guid customerId, CustomerAccountForCreationDto creationDto)
        {
            CustomerAccount newCustomerAccount = MappingToNewObj<CustomerAccount> (creationDto);
            newCustomerAccount.CustomerId = customerId;
            _repositoryManager.CustomerAccount.Create(newCustomerAccount);
            _repositoryManager.SaveChanges();

            return MappingToNewObj<CustomerAccountDto>(newCustomerAccount);
        }

        public void Update(Guid customerId, CustomerAccountForUpdateDto updateDto)
        {
            CustomerAccount? customerAccount = _repositoryManager.CustomerAccount.GetOneByCustomerId(isTrackChanges: true, customerId);
            if (customerAccount == null)
            {
                throw new ExNotFoundInDB(nameof(CustomerAccountService), nameof(Update), typeof(CustomerAccount), customerId);
            }
            MappingToExistingObj(updateDto, customerAccount);
            _repositoryManager.SaveChanges();
        }

        public List<CustomerAccountDto> GetAll(bool isTrackChanges)
        {
            List<CustomerAccount> customerAccounts = _repositoryManager.CustomerAccount.GetAll(isTrackChanges);
            return MappingToNewObj<List<CustomerAccountDto>>(customerAccounts);
        }

        public CustomerAccountDto? GetOneByCustomerId(bool isTrackChanges, Guid customerId)
        {
            if (_repositoryManager.Customer.IsValidId(customerId) == false)
            {
                throw new ExNotFoundInDB(nameof(CustomerAccountService), nameof(GetOneByCustomerId), typeof(Customer), customerId);
            }
            CustomerAccount? customerAccount = _repositoryManager.CustomerAccount.GetOneByCustomerId(isTrackChanges, customerId);
            if (customerAccount == null)
            {
                throw new ExNotFoundInDB(nameof(CustomerAccountService), nameof(GetOneByCustomerId), typeof(CustomerAccount), customerId);
            }
            return MappingToNewObj<CustomerAccountDto>(customerAccount);
        }

    }
}
