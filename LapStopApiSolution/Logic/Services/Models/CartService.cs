﻿using AutoMapper;
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

        public CartDto? GetOneByCustomerId(bool isTrackChanges, Guid customerId)
        {
            if (_repositoryManager.Customer.IsValidId(customerId) == false)
            {
                throw new ExNotFoundInDB(nameof(CartService), nameof(GetOneByCustomerId), typeof(Customer), customerId);
            }
            Cart? cart = _repositoryManager.Cart.GetOneByCustomerId(isTrackChanges, customerId);
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
