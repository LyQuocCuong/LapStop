namespace Services.Entities
{
    internal sealed class CustomerService : AbstractService, ICustomerService
    {
        public CustomerService(ServiceParams serviceParams) : base(serviceParams)
        {
        }

        private async Task<Customer> GetCustomerAndCheckIfItExists(bool isTrackChanges, Guid customerId)
        {
            Customer? customer = await EntityRepositories.Customer.GetOneByIdAsync(isTrackChanges, customerId);
            if (customer == null)
            {
                throw new ExNotFoundInDBModel(nameof(CustomerService), nameof(GetCustomerAndCheckIfItExists), typeof(Customer), customerId);
            }
            return customer;
        }

        public async Task<PagedList<CustomerDto>> GetAllAsync(HateoasParams<CustomerRequestParam> hateoasParams)
        {
            IEnumerable<Customer> customers = await EntityRepositories.Customer.GetAllAsync(isTrackChanges: false, hateoasParams.RequestParams);
            int totalRecords = await EntityRepositories.Customer.CountAllAsync(hateoasParams.RequestParams);
            var sourceDto = UtilityServices.Mapper.ExecuteMapping<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);

            var hateoasModels = UtilityServices.HateoasForCustomer.Execute(hateoasParams.HttpContext, sourceDto);

            return new PagedList<CustomerDto>(
                hateoasModels.ToList(),
                totalRecords,
                hateoasParams.RequestParams.PageNumber,
                hateoasParams.RequestParams.PageSize);
        }

        public async Task<CustomerDto?> GetOneByIdAsync(Guid customerId)
        {
            Customer customer = await GetCustomerAndCheckIfItExists(isTrackChanges: false, customerId);
            return UtilityServices.Mapper.ExecuteMapping<Customer, CustomerDto>(customer);
        }

        public async Task<CustomerForUpdateDto> GetDtoForPatchAsync(Guid customerId)
        {
            Customer? customer = await EntityRepositories.Customer.GetOneByIdAsync(isTrackChanges: false, customerId);
            return UtilityServices.Mapper.ExecuteMapping<Customer, CustomerForUpdateDto>(customer);
        }

        public async Task<bool> IsValidIdAsync(Guid customerId)
        {
            return await EntityRepositories.Customer.IsValidIdAsync(customerId);
        }

        public async Task<CustomerDto> CreateAsync(CustomerForCreationDto creationDto)
        {
            Customer newCustomer = UtilityServices.Mapper.ExecuteMapping<CustomerForCreationDto, Customer>(creationDto);
            EntityRepositories.Customer.Create(newCustomer);
            await SaveChangesToDatabaseAsync();

            return UtilityServices.Mapper.ExecuteMapping<Customer, CustomerDto>(newCustomer);
        }

        public async Task UpdateAsync(Guid customerId, CustomerForUpdateDto updateDto)
        {
            Customer customer = await GetCustomerAndCheckIfItExists(isTrackChanges: true, customerId);
            UtilityServices.Mapper.ExecuteMapping<CustomerForUpdateDto, Customer>(updateDto, customer);
            await SaveChangesToDatabaseAsync();
        }

        public async Task DeleteAsync(Guid customerId)
        {
            Customer customer = await GetCustomerAndCheckIfItExists(isTrackChanges: true, customerId);
            EntityRepositories.Customer.Delete(customer);
            await SaveChangesToDatabaseAsync();
        }
    }
}
