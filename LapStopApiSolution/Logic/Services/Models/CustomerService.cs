using Common.Models.DynamicObjects;
using Common.Models.Exceptions;
using Contracts.IDataShaper;
using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;

namespace Services.Models
{
    internal sealed class CustomerService : ServiceBase, ICustomerService
    {
        private readonly IDataShaperService<CustomerDto> _dataShaper;

        public CustomerService(ILogService logService,
                            IMappingService mappingService,
                            IRepositoryManager repositoryManager,
                            IDataShaperService<CustomerDto> dataShaper)
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

        public async Task<PagedList<DynamicModel>> GetAllAsync(CustomerParameters parameters)
        {
            IEnumerable<Customer> customers = await _repositoryManager.Customer.GetAllAsync(isTrackChanges: false, parameters);
            int totalRecords = await _repositoryManager.Customer.CountAllAsync(parameters);

            var sourceDto = _mappingService.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);

            var shapedData = _dataShaper.ShapingData(sourceDto, parameters.Fields);

            return new PagedList<DynamicModel>(shapedData.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);
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
