using Common.Models.Exceptions;
using Contracts.ILog;
using Contracts.IMapping;
using Contracts.IRepositories;
using Contracts.IServices.Models;
using Domains.Models;
using DTO.Output.Data;

namespace Services.Models
{
    internal sealed class CartService : ServiceBase, ICartService
    {
        public CartService(ILogService logService,
                            IMappingService mappingService,
                            IRepositoryManager repositoryManager)
            : base(logService,
                  mappingService,
                  repositoryManager)
        {
        }

        public async Task<IEnumerable<CartDto>> GetAllAsync()
        {
            IEnumerable<Cart> carts = await _repositoryManager.Cart.GetAllAsync(isTrackChanges: false);
            return _mappingService.Map<IEnumerable<Cart>, IEnumerable<CartDto>>(carts);
        }

        public async Task<CartDto?> GetOneByCustomerIdAsync(Guid customerId)
        {
            if (await _repositoryManager.Customer.IsValidIdAsync(customerId) == false)
            {
                throw new ExNotFoundInDBModel(nameof(CartService), nameof(GetOneByCustomerIdAsync), typeof(Customer), customerId);
            }
            Cart? cart = await _repositoryManager.Cart.GetOneByCustomerIdAsync(isTrackChanges: false, customerId);
            if (cart == null)
            {
                throw new ExNotFoundInDBModel(nameof(CartService), nameof(GetOneByCustomerIdAsync), typeof(Cart), customerId);
            }
            return _mappingService.Map<Cart, CartDto>(cart);
        }

        public async Task<bool> IsValidIdAsync(Guid cartId)
        {
            return await _repositoryManager.Cart.IsValidIdAsync(cartId);
        }
    }
}
