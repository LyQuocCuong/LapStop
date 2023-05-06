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

        public IEnumerable<CartDto> GetAll()
        {
            IEnumerable<Cart> carts = _repositoryManager.Cart.GetAll(isTrackChanges: false);
            return MappingToNewObj<IEnumerable<CartDto>>(carts);
        }

        public CartDto? GetOneByCustomerId(Guid customerId)
        {
            if (_repositoryManager.Customer.IsValidId(customerId) == false)
            {
                throw new ExNotFoundInDB(nameof(CartService), nameof(GetOneByCustomerId), typeof(Customer), customerId);
            }
            Cart? cart = _repositoryManager.Cart.GetOneByCustomerId(isTrackChanges: false, customerId);
            if (cart == null)
            {
                throw new ExNotFoundInDB(nameof(CartService), nameof(GetOneByCustomerId), typeof(Cart), customerId);
            }
            return MappingToNewObj<CartDto>(cart);
        }

        public bool IsValidId(Guid cartId)
        {
            return _repositoryManager.Cart.IsValidId(cartId);
        }
    }
}
