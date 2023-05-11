using DTO.Input.FromBody.Creation;
using DTO.Input.FromBody.Update;
using DTO.Input.FromQuery.Parameters;
using DTO.Output.Data;
using DTO.Output.PagedList;

namespace Contracts.IServices.Models
{
    public interface ICustomerService
    {
        Task<PagedList<CustomerDto>> GetAllAsync(CustomerParameters parameters);

        Task<CustomerDto?> GetOneByIdAsync(Guid customerId);

        Task<CustomerForUpdateDto> GetDtoForPatchAsync(Guid customerId);

        Task<bool> IsValidIdAsync(Guid customerId);

        Task<CustomerDto> CreateAsync(CustomerForCreationDto creationDto);

        Task UpdateAsync(Guid customerId, CustomerForUpdateDto updateDto);

        Task DeleteAsync(Guid customerId);

    }
}
