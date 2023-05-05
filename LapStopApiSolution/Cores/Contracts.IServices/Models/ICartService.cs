using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICartService
    {
        List<CartDto> GetAll();

        CartDto? GetOneByCustomerId(Guid customerId);

        bool IsValidId(Guid cartId);
    }
}
