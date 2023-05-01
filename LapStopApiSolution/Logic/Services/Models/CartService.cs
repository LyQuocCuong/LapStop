using AutoMapper;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output;
using Shared.CustomModels.Exceptions;

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
            return MappingToNewObj<List<CartDto>>(carts);
        }

        public CartDto? GetByCustomerId(bool isTrackChanges, Guid customerId)
        {
            if (_repositoryManager.Customer.IsValidCustomerId(customerId) == false)
            {
                throw new ExNotFoundInDB(nameof(CartService), nameof(GetByCustomerId), typeof(Customer), customerId);
            }
            Cart? cart = _repositoryManager.Cart.GetByCustomerId(isTrackChanges, customerId);
            if (cart == null)
            {
                throw new ExNotFoundInDB(nameof(CartService), nameof(GetByCustomerId), typeof(Cart), customerId);
            }
            return MappingToNewObj<CartDto>(cart);
        }

        public bool IsValidCartId(Guid cartId)
        {
            return _repositoryManager.Cart.IsValidCartId(cartId);
        }
    }
}
