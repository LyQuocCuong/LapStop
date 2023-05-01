using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICartService
    {
        List<CartDto> GetAll(bool isTrackChanges);

        CartDto? GetOneByCustomerId(bool isTrackChanges, Guid customerId);

        bool IsValidId(Guid cartId);
    }
}
