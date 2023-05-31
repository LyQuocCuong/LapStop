using AutoMapper;
using Common.Models.Exceptions;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class CartItemService : ServiceBase, ICartItemService
    {
        public CartItemService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<CartItemDto>> GetAllByCartIdAsync(Guid cartId)
        {
            if (await _repositoryManager.Cart.IsValidIdAsync(cartId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(CartItemService), nameof(GetAllByCartIdAsync), typeof(Cart), cartId);
            }
            IEnumerable<CartItem> cartItems = await _repositoryManager.CartItem.GetAllByCartIdAsync(isTrackChanges: false, cartId);
            return MappingToNewObj<IEnumerable<CartItemDto>>(cartItems);
        }
    }
}
