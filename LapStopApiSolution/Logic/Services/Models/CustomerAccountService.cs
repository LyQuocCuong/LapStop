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

        public async Task<CustomerAccountDto> CreateAsync(Guid customerId, CustomerAccountForCreationDto creationDto)
        {
            CustomerAccount newCustomerAccount = MappingToNewObj<CustomerAccount> (creationDto);
            newCustomerAccount.CustomerId = customerId;
            _repositoryManager.CustomerAccount.Create(newCustomerAccount);
            await _repositoryManager.SaveChangesAsync();

            return MappingToNewObj<CustomerAccountDto>(newCustomerAccount);
        }

        public async Task UpdateAsync(Guid customerId, CustomerAccountForUpdateDto updateDto)
        {
            CustomerAccount? customerAccount = await _repositoryManager.CustomerAccount.GetOneByCustomerIdAsync(isTrackChanges: true, customerId);
            if (customerAccount == null)
            {
                throw new ExNotFoundInDB(nameof(CustomerAccountService), nameof(UpdateAsync), typeof(CustomerAccount), customerId);
            }
            MappingToExistingObj(updateDto, customerAccount);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerAccountDto>> GetAllAsync()
        {
            IEnumerable<CustomerAccount> customerAccounts = await _repositoryManager.CustomerAccount.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<CustomerAccountDto>>(customerAccounts);
        }

        public async Task<CustomerAccountDto?> GetOneByCustomerIdAsync(Guid customerId)
        {
            if (await _repositoryManager.Customer.IsValidIdAsync(customerId) == false)
            {
                throw new ExNotFoundInDB(nameof(CustomerAccountService), nameof(GetOneByCustomerIdAsync), typeof(Customer), customerId);
            }
            CustomerAccount? customerAccount = await _repositoryManager.CustomerAccount.GetOneByCustomerIdAsync(isTrackChanges: false, customerId);
            if (customerAccount == null)
            {
                throw new ExNotFoundInDB(nameof(CustomerAccountService), nameof(GetOneByCustomerIdAsync), typeof(CustomerAccount), customerId);
            }
            return MappingToNewObj<CustomerAccountDto>(customerAccount);
        }

    }
}
