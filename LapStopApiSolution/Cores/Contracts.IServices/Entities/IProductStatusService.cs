namespace Contracts.IServices.Entities
{
    public interface IProductStatusService
    {
        Task<IEnumerable<ProductStatusDto>> GetAllAsync();

        Task<ProductStatusDto?> GetOneByIdAsync(Guid productStatusId);
    }
}
