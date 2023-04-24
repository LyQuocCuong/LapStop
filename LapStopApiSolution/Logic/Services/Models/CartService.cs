using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomedExceptions;

namespace Services.Models
{
    internal sealed class CartService : ServiceBase, ICartService
    {
        public CartService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<CartDto> GetAll(bool isTrackChanges)
        {
            List<Cart> carts = _repositoryManager.Cart.GetAll(isTrackChanges);
            return MappingTo<List<CartDto>>(carts);
        }

        public CartDto? GetByCustomerId(bool isTrackChanges, Guid customerId)
        {
            if (_repositoryManager.Customer.IsValidCustomerId(customerId) == false)
            {
                throw new NotFoundException404(nameof(CartService), nameof(GetByCustomerId), typeof(Customer), customerId);
            }
            Cart? cart = _repositoryManager.Cart.GetByCustomerId(isTrackChanges, customerId);
            if (cart == null)
            {
                throw new NotFoundException404(nameof(CartService), nameof(GetByCustomerId), typeof(Cart), customerId);
            }
            return MappingTo<CartDto>(cart);
        }

        public bool IsValidCartId(Guid cartId)
        {
            return _repositoryManager.Cart.IsValidCartId(cartId);
        }
    }
}
