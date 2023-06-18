namespace RestfulApiHandler.Controllers.Models
{
    [ApiController]
    [Route("api")]
    public class InvoiceStatusController : RootController
    {
        public InvoiceStatusController(ILogService logService,
                                       IServiceManager serviceManager)
                                 : base(logService, serviceManager)
        {
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
