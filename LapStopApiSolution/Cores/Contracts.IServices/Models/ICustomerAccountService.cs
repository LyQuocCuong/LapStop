using DTO.Creation;
using DTO.Output;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface ICustomerAccountService
    {
        Task<IEnumerable<CustomerAccountDto>> GetAllAsync();

        Task<CustomerAccountDto?> GetOneByCustomerIdAsync(Guid customerId);

        Task<CustomerAccountDto> CreateAsync(Guid customerId, CustomerAccountForCreationDto creationDto);

        Task UpdateAsync(Guid customerId, CustomerAccountForUpdateDto updateDto);
    }
}
