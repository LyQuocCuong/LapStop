namespace RestfulApiHandler.Controllers.Entities
{
    [ApiController]
    [Route("api")]
    public class SalesOrderStatusController : AbstractController
    {
        public SalesOrderStatusController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("salesorderstatuses", Name = "GetAllSalesOrderStatuses")]
        public async Task<IActionResult> GetAllSalesOrderStatuses()
        {
            IEnumerable<SalesOrderStatusDto> salesOrderStatusDtos = await EntityServices.SalesOrderStatus.GetAllAsync();
            return Ok(salesOrderStatusDtos);
        }

        [HttpGet]
        [Route("salesorderstatuses/{salesOrderStatusId:guid}", Name = "GetSalesOrderStatusById")]
        public async Task<IActionResult> GetSalesOrderStatusById(Guid salesOrderStatusId)
        {
            SalesOrderStatusDto? salesOrderStatusDto = await EntityServices.SalesOrderStatus.GetOneByIdAsync(salesOrderStatusId);
            if (salesOrderStatusDto == null)
            {
                return NotFound();
            }
            return Ok(salesOrderStatusDto);
        }

    }
}
