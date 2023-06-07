namespace Services.Models
{
    internal sealed class CustomerService : ServiceBase, ICustomerService
    {
        private readonly IDataShaperService<CustomerDto, ExpandoForXmlObject> _dataShaper;

        public CustomerService(ILogService logService,
                            IMappingService mappingService,
                            IRepositoryManager repositoryManager,
                            IDataShaperService<CustomerDto, ExpandoForXmlObject> dataShaper)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
            _dataShaper = dataShaper;
        }

        private async Task<Customer> GetCustomerAndCheckIfItExists(bool isTrackChanges, Guid customerId)
        {
            Customer? customer = await _repositoryManager.Customer.GetOneByIdAsync(isTrackChanges, customerId);
            if (customer == null)
            {
                throw new ExNotFoundInDBModel(nameof(CustomerService), nameof(GetCustomerAndCheckIfItExists), typeof(Customer), customerId);
            }
            return customer;
        }

        public async Task<PagedList<ExpandoForXmlObject>> GetAllAsync(CustomerRequestParam parameters)
        {
            //IEnumerable<Customer> customers = await _repositoryManager.Customer.GetAllAsync(isTrackChanges: false, parameters);
            //int totalRecords = await _repositoryManager.Customer.CountAllAsync(parameters);

            //var sourceDto = _mappingService.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);

            //var shapedData = _dataShaper.ShapingData(sourceDto, parameters.Fields);

            //return new PagedList<DynamicModel>(shapedData.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);

            return new PagedList<ExpandoForXmlObject>(new List<ExpandoForXmlObject>(),0, 0, 0);
        }

        public async Task<CustomerDto?> GetOneByIdAsync(Guid customerId)
        {
            Customer customer = await GetCustomerAndCheckIfItExists(isTrackChanges: false, customerId);
            return _mappingService.Map<Customer, CustomerDto>(customer);
        }

        public async Task<CustomerForUpdateDto> GetDtoForPatchAsync(Guid customerId)
        {
            Customer? customer = await _repositoryManager.Customer.GetOneByIdAsync(isTrackChanges: false, customerId);
            return _mappingService.Map<Customer, CustomerForUpdateDto>(customer);
        }

        public async Task<bool> IsValidIdAsync(Guid customerId)
        {
            return await _repositoryManager.Customer.IsValidIdAsync(customerId);
        }

        public async Task<CustomerDto> CreateAsync(CustomerForCreationDto creationDto)
        {
            Customer newCustomer = _mappingService.Map<CustomerForCreationDto, Customer>(creationDto);
            _repositoryManager.Customer.Create(newCustomer);
            await _repositoryManager.SaveChangesAsync();

            return _mappingService.Map<Customer, CustomerDto>(newCustomer);
        }

        public async Task UpdateAsync(Guid customerId, CustomerForUpdateDto updateDto)
        {
            Customer customer = await GetCustomerAndCheckIfItExists(isTrackChanges: true, customerId);
            _mappingService.Map<CustomerForUpdateDto, Customer>(updateDto, customer);
            await _repositoryManager.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid customerId)
        {
            Customer customer = await GetCustomerAndCheckIfItExists(isTrackChanges: true, customerId);
            _repositoryManager.Customer.Delete(customer);
            await _repositoryManager.SaveChangesAsync();
        }
    }
}
