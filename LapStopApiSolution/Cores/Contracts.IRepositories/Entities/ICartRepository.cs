namespace Contracts.IRepositories.Entities
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetAllAsync(bool isTrackChanges);

        Task<Cart?> GetOneByCustomerIdAsync(bool isTrackChanges, Guid customerId);

        Task<bool> IsValidIdAsync(Guid cartId);
    }
}
