using Common.Models.Exceptions;
using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class CustomerAccountService : ServiceBase, ICustomerAccountService
    {
        public CustomerAccountService(ILogService logService,
                                       IMappingService mappingService,
                                       IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<CustomerAccountDto> CreateAsync(Guid customerId, CustomerAccountForCreationDto creationDto)
        {
            CustomerAccount newCustomerAccount = _mappingService.Map<CustomerAccountForCreationDto, CustomerAccount>(creationDto);
            newCustomerAccount.CustomerId = customerId;
            _repositoryManager.CustomerAccount.Create(newCustomerAccount);
            await _repositoryManager.SaveChangesAsync();

            return _mappingService.Map<CustomerAccount, CustomerAccountDto>(newCustomerAccount);
        }

        public async Task UpdateAsync(Guid customerId, CustomerAccountForUpdateDto updateDto)
        {
            CustomerAccount? customerAccount = await _repositoryManager.CustomerAccount.GetOneByCustomerIdAsync(isTrackChanges: true, customerId);
            if (customerAccount == null)
            {
                throw new ExNotFoundInDBModel(nameof(CustomerAccountService), nameof(UpdateAsync), typeof(CustomerAccount), customerId);
            }
            _mappingService.Map<CustomerAccountForUpdateDto, CustomerAccount>(updateDto, customerAccount);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerAccountDto>> GetAllAsync()
        {
            IEnumerable<CustomerAccount> customerAccounts = await _repositoryManager.CustomerAccount.GetAllAsync(isTrackChanges: false);
            return _mappingService.Map<IEnumerable<CustomerAccount>, IEnumerable<CustomerAccountDto>>(customerAccounts);
        }

        public async Task<CustomerAccountDto?> GetOneByCustomerIdAsync(Guid customerId)
        {
            if (await _repositoryManager.Customer.IsValidIdAsync(customerId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(CustomerAccountService), nameof(GetOneByCustomerIdAsync), typeof(Customer), customerId);
            }
            CustomerAccount? customerAccount = await _repositoryManager.CustomerAccount.GetOneByCustomerIdAsync(isTrackChanges: false, customerId);
            if (customerAccount == null)
            {
                throw new ExNotFoundInDBModel(nameof(CustomerAccountService), nameof(GetOneByCustomerIdAsync), typeof(CustomerAccount), customerId);
            }
            return _mappingService.Map<CustomerAccount, CustomerAccountDto>(customerAccount);
        }

    }
}
