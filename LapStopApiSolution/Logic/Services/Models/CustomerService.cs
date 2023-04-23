using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomedExceptions;

namespace Services.Models
{
    internal sealed class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<CustomerDto> GetAll(bool isTrackChanges)
        {
            List<Customer> customers = _repositoryManager.Customer.GetAll(isTrackChanges);
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public CustomerDto? GetById(bool isTrackChanges, Guid id)
        {
            Customer? customer = _repositoryManager.Customer.GetById(isTrackChanges, id);
            if (customer == null)
            {
                throw new NotFoundException404(typeof(Customer), nameof(GetById), id);
            }
            return _mapper.Map<CustomerDto>(customer);
        }

        public bool IsValidCustomerId(Guid customerId)
        {
            return _repositoryManager.Customer.IsValidCustomerId(customerId);
        }
    }
}
