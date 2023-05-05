using DTO.Creation;
using DTO.Output;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface ICustomerAccountService
    {
        List<CustomerAccountDto> GetAll();

        CustomerAccountDto? GetOneByCustomerId(Guid customerId);

        CustomerAccountDto Create(Guid customerId, CustomerAccountForCreationDto creationDto);

        void Update(Guid customerId, CustomerAccountForUpdateDto updateDto);
    }
}
