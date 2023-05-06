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
    internal sealed class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public CustomerDto Create(CustomerForCreationDto creationDto)
        {
            Customer newCustomer = MappingToNewObj<Customer>(creationDto);
            _repositoryManager.Customer.Create(newCustomer);
            _repositoryManager.SaveChanges();

            return MappingToNewObj<CustomerDto>(newCustomer);
        }

        public void Update(Guid customerId, CustomerForUpdateDto updateDto)
        {
            Customer? customer = _repositoryManager.Customer.GetOneById(isTrackChanges: true, customerId);
            if (customer == null)
            {
                throw new ExNotFoundInDB(nameof(CustomerService), nameof(Update), typeof(Customer), customerId);
            }
            MappingToExistingObj(updateDto, customer);
            _repositoryManager.SaveChanges();
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            IEnumerable<Customer> customers = _repositoryManager.Customer.GetAll(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<CustomerDto>>(customers);
        }

        public CustomerDto? GetOneById(Guid customerId)
        {
            Customer? customer = _repositoryManager.Customer.GetOneById(isTrackChanges: false, customerId);
            if (customer == null)
            {
                throw new ExNotFoundInDB(nameof(CustomerService), nameof(GetOneById), typeof(Customer), customerId);
            }
            return MappingToNewObj<CustomerDto>(customer);
        }

        public CustomerForUpdateDto GetDtoForPatch(Guid customerId)
        {
            Customer? customer = _repositoryManager.Customer.GetOneById(isTrackChanges: false, customerId);
            return MappingToNewObj<CustomerForUpdateDto>(customer);
        }

        public bool IsValidId(Guid customerId)
        {
            return _repositoryManager.Customer.IsValidId(customerId);
        }

    }
}
