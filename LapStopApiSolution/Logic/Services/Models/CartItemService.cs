using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class CartItemService : ServiceBase, ICartItemService
    {
        public CartItemService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public IEnumerable<CartItemDto> GetAllByCartId(Guid cartId)
        {
            if (_repositoryManager.Cart.IsValidId(cartId) == false)
            {
                throw new ExNotFoundInDB(nameof(CartItemService), nameof(GetAllByCartId), typeof(Cart), cartId);
            }
            IEnumerable<CartItem> cartItems = _repositoryManager.CartItem.GetAllByCartId(isTrackChanges: false, cartId);
            return MappingToNewObj<IEnumerable<CartItemDto>>(cartItems);
        }
    }
}
