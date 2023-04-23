using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICartService
    {
        List<CartDto> GetAll(bool isTrackChanges);
        CartDto? GetByCustomerId(bool isTrackChanges, Guid customerId);
        bool IsValidCartId(Guid cartId);
    }
}
