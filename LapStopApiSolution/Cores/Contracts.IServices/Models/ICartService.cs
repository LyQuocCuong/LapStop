namespace Contracts.IServices.Models
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetAllAsync();

        Task<CartDto?> GetOneByCustomerIdAsync(Guid customerId);

        Task<bool> IsValidIdAsync(Guid cartId);
    }
}
