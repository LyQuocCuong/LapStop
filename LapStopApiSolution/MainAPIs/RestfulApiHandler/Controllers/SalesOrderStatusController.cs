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
    [Route("api/salesorderstatuses")]
    public class SalesOrderStatusController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public SalesOrderStatusController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<SalesOrderStatusDto> salesOrderStatusDtos = _serviceManager.SalesOrderStatus.GetAll(isTrackChanges: false);
            return Ok(salesOrderStatusDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            SalesOrderStatusDto? salesOrderStatusDto = _serviceManager.SalesOrderStatus.GetById(isTrackChanges: false, id);
            if (salesOrderStatusDto == null)
            {
                return NotFound();
            }
            return Ok(salesOrderStatusDto);
        }

    }
}
