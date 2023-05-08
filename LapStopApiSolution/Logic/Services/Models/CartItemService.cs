using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;
using Shared.CustomModels.Exceptions;

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
                throw new ExNotFoundInDB(nameof(CartItemService), nameof(GetAllByCartIdAsync), typeof(Cart), cartId);
            }
            IEnumerable<CartItem> cartItems = await _repositoryManager.CartItem.GetAllByCartIdAsync(isTrackChanges: false, cartId);
            return MappingToNewObj<IEnumerable<CartItemDto>>(cartItems);
        }
    }
}
