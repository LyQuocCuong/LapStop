using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class CartController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public CartController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [Route("customers/{customerId: guid}/cart")]
        public IActionResult GetByCustomerId(Guid customerId)
        {
            if ()

            CartDto? cartDto = _serviceManager.Cart.GetByCustomerId(isTrackChanges: false, customerId);
            if (cartDto == null)
            {
                return NotFound();
            }
            return Ok(cartDto);
        }

        [HttpGet("customers")]
        public IActionResult GetAll(Guid id)
        {
            List<CartDto> cartDtos = _serviceManager.Cart.GetAll(isTrackChanges: false);
            return Ok(cartDtos);
        }

    }
}
