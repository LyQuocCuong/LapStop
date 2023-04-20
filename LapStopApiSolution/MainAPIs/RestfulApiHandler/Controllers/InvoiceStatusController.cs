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
    [Route("api/invoicestatuses")]
    public class InvoiceStatusController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public InvoiceStatusController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<InvoiceStatusDto> invoiceStatusDtos = _serviceManager.InvoiceStatus.GetAll(isTrackChanges: false);
            return Ok(invoiceStatusDtos);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            InvoiceStatusDto? invoiceStatusDto = _serviceManager.InvoiceStatus.GetById(isTrackChanges: false, id);
            if (invoiceStatusDto == null)
            {
                return NotFound();
            }
            return Ok(invoiceStatusDto);
        }

    }
}
