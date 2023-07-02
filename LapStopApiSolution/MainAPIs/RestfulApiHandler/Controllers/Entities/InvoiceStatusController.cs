namespace RestfulApiHandler.Controllers.Entities
{
    [ApiController]
    [Route("api")]
    public class InvoiceStatusController : AbstractApiControllerVer01
    {
        public InvoiceStatusController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("invoicestatuses", Name = "GetAllInvoiceStatuses")]
        public async Task<IActionResult> GetAllInvoiceStatuses()
        {
            IEnumerable<InvoiceStatusDto> invoiceStatusDtos = await EntityServices.InvoiceStatus.GetAllAsync();
            return Ok(invoiceStatusDtos);
        }

        [HttpGet]
        [Route("invoicestatuses/{invoiceStatusId:guid}", Name = "GetInvoiceStatusById")]
        public async Task<IActionResult> GetInvoiceStatusById(Guid invoiceStatusId)
        {
            InvoiceStatusDto? invoiceStatusDto = await EntityServices.InvoiceStatus.GetOneByIdAsync(invoiceStatusId);
            if (invoiceStatusDto == null)
            {
                return NotFound();
            }
            return Ok(invoiceStatusDto);
        }

    }
}
