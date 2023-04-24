using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomedExceptions;

namespace Services.Models
{
    internal sealed class CartItemService : ServiceBase, ICartItemService
    {
        public CartItemService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public List<CartItemDto> GetByCartId(bool isTrackChanges, Guid cartId)
        {
            if (_repositoryManager.Cart.IsValidCartId(cartId) == false)
            {
                throw new NotFoundException404(typeof(Cart), nameof(GetByCartId), cartId);
            }
            List<CartItem> cartItems = _repositoryManager.CartItem.GetByCartId(isTrackChanges: false, cartId);
            return MappingTo<List<CartItemDto>>(cartItems);
        }
    }
}
