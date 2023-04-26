using DTO.Creation;
using DTO.Output;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface ICustomerAccountService
    {
        List<CustomerAccountDto> GetAll(bool isTrackChanges);

        CustomerAccountDto? GetByCustomerId(bool isTrackChanges, Guid customerId);

        CustomerAccountDto CreateCustomerAccount(Guid customerId, CustomerAccountForCreationDto creationDto);

        void UpdateCustomerAccount(Guid customerId, CustomerAccountForUpdateDto updateDto);
    }
}
