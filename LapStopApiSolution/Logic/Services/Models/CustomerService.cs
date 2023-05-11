using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        private async Task<Customer> GetCustomerAndCheckIfItExists(bool isTrackChanges, Guid customerId)
        {
            Customer? customer = await _repositoryManager.Customer.GetOneByIdAsync(isTrackChanges, customerId);
            if (customer == null)
            {
                throw new ExNotFoundInDB(nameof(CustomerService), nameof(GetCustomerAndCheckIfItExists), typeof(Customer), customerId);
            }
            return customer;
        }

        public async Task<PagedList<CustomerDto>> GetAllAsync(CustomerParameters parameters)
        {
            IEnumerable<Customer> customers = await _repositoryManager.Customer.GetAllAsync(isTrackChanges: false, parameters);
            int totalRecords = await _repositoryManager.Customer.CountAllAsync(parameters);

            var sourceDto = MappingToNewObj<IEnumerable<CustomerDto>>(customers);
            return new PagedList<CustomerDto>(sourceDto.ToList(), totalRecords, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CustomerDto?> GetOneByIdAsync(Guid customerId)
        {
            Customer customer = await GetCustomerAndCheckIfItExists(isTrackChanges: false, customerId);
            return MappingToNewObj<CustomerDto>(customer);
        }

        public async Task<CustomerForUpdateDto> GetDtoForPatchAsync(Guid customerId)
        {
            Customer? customer = await _repositoryManager.Customer.GetOneByIdAsync(isTrackChanges: false, customerId);
            return MappingToNewObj<CustomerForUpdateDto>(customer);
        }

        public async Task<bool> IsValidIdAsync(Guid customerId)
        {
            return await _repositoryManager.Customer.IsValidIdAsync(customerId);
        }

        public async Task<CustomerDto> CreateAsync(CustomerForCreationDto creationDto)
        {
            Customer newCustomer = MappingToNewObj<Customer>(creationDto);
            _repositoryManager.Customer.Create(newCustomer);
            await _repositoryManager.SaveChangesAsync();

            return MappingToNewObj<CustomerDto>(newCustomer);
        }

        public async Task UpdateAsync(Guid customerId, CustomerForUpdateDto updateDto)
        {
            Customer customer = await GetCustomerAndCheckIfItExists(isTrackChanges: true, customerId);
            MappingToExistingObj(updateDto, customer);
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
