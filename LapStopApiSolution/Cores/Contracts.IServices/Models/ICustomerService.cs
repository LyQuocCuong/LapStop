namespace Contracts.IServices.Models
{
    public interface ICustomerService
    {
        Task<PagedList<ExpandoForXmlObject>> GetAllAsync(CustomerRequestParam parameters);

        Task<CustomerDto?> GetOneByIdAsync(Guid customerId);

        Task<CustomerForUpdateDto> GetDtoForPatchAsync(Guid customerId);

        Task<bool> IsValidIdAsync(Guid customerId);

        Task<CustomerDto> CreateAsync(CustomerForCreationDto creationDto);

        Task UpdateAsync(Guid customerId, CustomerForUpdateDto updateDto);

        Task DeleteAsync(Guid customerId);

    }
}
