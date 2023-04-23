using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICustomerService
    {
        List<CustomerDto> GetAll(bool isTrackChanges);
        CustomerDto? GetById(bool isTrackChanges, Guid id);
        bool IsValidCustomerId(Guid customerId);
    }
}
