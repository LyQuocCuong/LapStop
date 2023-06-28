namespace Services.Entities
{
    internal sealed class CustomerAccountService : AbstractService, ICustomerAccountService
    {
        public CustomerAccountService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        public async Task<CustomerAccountDto> CreateAsync(Guid customerId, CustomerAccountForCreationDto creationDto)
        {
            CustomerAccount newCustomerAccount = UtilityServices.Mapper.ExecuteMapping<CustomerAccountForCreationDto, CustomerAccount>(creationDto);
            newCustomerAccount.CustomerId = customerId;
            EntityRepositories.CustomerAccount.Create(newCustomerAccount);
            await SaveChangesToDatabaseAsync();

            return UtilityServices.Mapper.ExecuteMapping<CustomerAccount, CustomerAccountDto>(newCustomerAccount);
        }

        public async Task UpdateAsync(Guid customerId, CustomerAccountForUpdateDto updateDto)
        {
            CustomerAccount? customerAccount = await EntityRepositories.CustomerAccount.GetOneByCustomerIdAsync(isTrackChanges: true, customerId);
            if (customerAccount == null)
            {
                throw new ExNotFoundInDBModel(nameof(CustomerAccountService), nameof(UpdateAsync), typeof(CustomerAccount), customerId);
            }
            UtilityServices.Mapper.ExecuteMapping<CustomerAccountForUpdateDto, CustomerAccount>(updateDto, customerAccount);
            await SaveChangesToDatabaseAsync();
        }

        public async Task<IEnumerable<CustomerAccountDto>> GetAllAsync()
        {
            IEnumerable<CustomerAccount> customerAccounts = await EntityRepositories.CustomerAccount.GetAllAsync(isTrackChanges: false);
            return UtilityServices.Mapper.ExecuteMapping<IEnumerable<CustomerAccount>, IEnumerable<CustomerAccountDto>>(customerAccounts);
        }

        public async Task<CustomerAccountDto?> GetOneByCustomerIdAsync(Guid customerId)
        {
            if (await EntityRepositories.Customer.IsValidIdAsync(customerId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(CustomerAccountService), nameof(GetOneByCustomerIdAsync), typeof(Customer), customerId);
            }
            CustomerAccount? customerAccount = await EntityRepositories.CustomerAccount.GetOneByCustomerIdAsync(isTrackChanges: false, customerId);
            if (customerAccount == null)
            {
                throw new ExNotFoundInDBModel(nameof(CustomerAccountService), nameof(GetOneByCustomerIdAsync), typeof(CustomerAccount), customerId);
            }
            return UtilityServices.Mapper.ExecuteMapping<CustomerAccount, CustomerAccountDto>(customerAccount);
        }

    }
}
