namespace Contracts.IServices.Entities
{
    public interface ICustomerAccountService
    {
        Task<IEnumerable<CustomerAccountDto>> GetAllAsync();

        Task<CustomerAccountDto?> GetOneByCustomerIdAsync(Guid customerId);

        Task<CustomerAccountDto> CreateAsync(Guid customerId, CustomerAccountForCreationDto creationDto);

        Task UpdateAsync(Guid customerId, CustomerAccountForUpdateDto updateDto);
    }
}
