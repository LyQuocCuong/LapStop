using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
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
        [Route("invoicestatuses", Name = "GetAllInvoiceStatuses")]
        public async Task<IActionResult> GetAllInvoiceStatuses()
        {
            IEnumerable<InvoiceStatusDto> invoiceStatusDtos = await _serviceManager.InvoiceStatus.GetAllAsync();
            return Ok(invoiceStatusDtos);
        }

        [HttpGet]
        [Route("invoicestatuses/{invoiceStatusId:guid}", Name = "GetInvoiceStatusById")]
        public async Task<IActionResult> GetInvoiceStatusById(Guid invoiceStatusId)
        {
            InvoiceStatusDto? invoiceStatusDto = await _serviceManager.InvoiceStatus.GetOneByIdAsync(invoiceStatusId);
            if (invoiceStatusDto == null)
            {
                return NotFound();
            }
            return Ok(invoiceStatusDto);
        }

    }
}
