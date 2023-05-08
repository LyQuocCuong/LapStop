using DTO.Creation;
using DTO.Output;
using DTO.Parameters;
using DTO.Update;

namespace Contracts.IServices.Models
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync(CustomerParameters parameters);

        Task<CustomerDto?> GetOneByIdAsync(Guid customerId);

        Task<CustomerForUpdateDto> GetDtoForPatchAsync(Guid customerId);

        Task<bool> IsValidIdAsync(Guid customerId);

        Task<CustomerDto> CreateAsync(CustomerForCreationDto creationDto);

        Task UpdateAsync(Guid customerId, CustomerForUpdateDto updateDto);

    }
}
