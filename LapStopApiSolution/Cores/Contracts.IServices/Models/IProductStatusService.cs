using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductStatusService
    {
        List<ProductStatusDto> GetAll();

        ProductStatusDto? GetOneById(Guid productStatusId);
    }
}
