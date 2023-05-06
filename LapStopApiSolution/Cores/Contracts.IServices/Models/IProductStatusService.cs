using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductStatusService
    {
        IEnumerable<ProductStatusDto> GetAll();

        ProductStatusDto? GetOneById(Guid productStatusId);
    }
}
