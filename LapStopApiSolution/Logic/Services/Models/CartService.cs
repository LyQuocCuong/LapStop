using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;
using Shared.CustomModels.Exceptions;

namespace Services.Models
{
    internal sealed class CartService : ServiceBase, ICartService
    {
        public CartService(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            IEnumerable<Cart> carts = await _repositoryManager.Cart.GetAllAsync(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<CartDto>>(carts);
        }

        public async Task<CartDto?> GetOneByCustomerIdAsync(Guid customerId)
        {
            if (await _repositoryManager.Customer.IsValidIdAsync(customerId) == false)
            {
                throw new ExNotFoundInDB(nameof(CartService), nameof(GetOneByCustomerIdAsync), typeof(Customer), customerId);
            }
            Cart? cart = await _repositoryManager.Cart.GetOneByCustomerIdAsync(isTrackChanges: false, customerId);
            if (cart == null)
            {
                throw new ExNotFoundInDB(nameof(CartService), nameof(GetOneByCustomerIdAsync), typeof(Cart), customerId);
            }
            return MappingToNewObj<CartDto>(cart);
        }

        public async Task<bool> IsValidIdAsync(Guid cartId)
        {
            return await _repositoryManager.Cart.IsValidIdAsync(cartId);
        }
    }
}
