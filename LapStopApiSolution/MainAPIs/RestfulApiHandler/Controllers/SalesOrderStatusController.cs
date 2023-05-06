using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
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
        [Route("salesorderstatuses", Name = "GetAllSalesOrderStatuses")]
        public IActionResult GetAllSalesOrderStatuses()
        {
            IEnumerable<SalesOrderStatusDto> salesOrderStatusDtos = _serviceManager.SalesOrderStatus.GetAll();
            return Ok(salesOrderStatusDtos);
        }

        [HttpGet]
        [Route("salesorderstatuses/{salesOrderStatusId:guid}", Name = "GetSalesOrderStatusById")]
        public IActionResult GetSalesOrderStatusById(Guid salesOrderStatusId)
        {
            SalesOrderStatusDto? salesOrderStatusDto = _serviceManager.SalesOrderStatus.GetOneById(salesOrderStatusId);
            if (salesOrderStatusDto == null)
            {
                return NotFound();
            }
            return Ok(salesOrderStatusDto);
        }

    }
}
