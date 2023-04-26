using DTO.Creation;
using DTO.Output;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAll(bool isTrackChanges);

        CustomerDto? GetById(bool isTrackChanges, Guid id);

        bool IsValidCustomerId(Guid customerId);

        CustomerDto CreateCustomer(CustomerForCreationDto creationDto);

        void UpdateCustomer(Guid id, CustomerForUpdateDto updateDto);

    }
}
