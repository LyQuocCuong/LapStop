﻿using DTO.Output;

namespace Contracts.IServices.Models
{
    public interface ICartItemService
    {
        List<CartItemDto> GetByCartId(bool isTrackChanges, Guid cartId);
    }
}
