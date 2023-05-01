﻿using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class CartItemController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public CartItemController(IServiceManager serviceManager, ILogService logService)
        {
            _serviceManager = serviceManager;
            _logService = logService;
        }

        [HttpGet]
        [Route("carts/{cartId:guid}/cartitems", Name = "GetAllCartItemsByCartId")]
        public IActionResult GetAllCartItemsByCartId(Guid cartId)
        {
            List<CartItemDto> cartItemDtos = _serviceManager.CartItem.GetAllByCartId(isTrackChanges: false, cartId);
            return Ok(cartItemDtos);
        }

    }
}