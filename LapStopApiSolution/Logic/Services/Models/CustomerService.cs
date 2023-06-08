using Common.Models.Hateoas;

namespace Services.Models
{
    internal sealed class CustomerService : ServiceBase, ICustomerService
    {
        private readonly IHateoasService<CustomerDto> _hateoasService;

        public CustomerService(ILogService logService,
                            IMappingService mappingService,
                            IRepositoryManager repositoryManager,
                            IHateoasService<CustomerDto> hateoasService)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
            _hateoasService = hateoasService;
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

        public async Task<PagedList<CustomerDto>> GetAllAsync(HateoasParams<CustomerRequestParam> hateoasParams)
        {
            IEnumerable<Customer> customers = await _repositoryManager.Customer.GetAllAsync(isTrackChanges: false, hateoasParams.RequestParams);
            int totalRecords = await _repositoryManager.Customer.CountAllAsync(hateoasParams.RequestParams);
            var sourceDto = _mappingService.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);

            var hateoasModels = _hateoasService.Execute(hateoasParams.HttpContext, sourceDto);

            return new PagedList<CustomerDto>(
                hateoasModels.ToList(),
                totalRecords,
                hateoasParams.RequestParams.PageNumber,
                hateoasParams.RequestParams.PageSize);
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
