using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductStatusService
    {
        Task<IEnumerable<ProductStatusDto>> GetAllAsync();

        Task<ProductStatusDto?> GetOneByIdAsync(Guid productStatusId);
    }
}
