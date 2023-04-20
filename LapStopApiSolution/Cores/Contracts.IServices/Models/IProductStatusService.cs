using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface IProductStatusService
    {
        List<ProductStatusDto> GetAll(bool isTrackChanges);
        ProductStatusDto? GetById(bool isTrackChanges, Guid id);
    }
}
