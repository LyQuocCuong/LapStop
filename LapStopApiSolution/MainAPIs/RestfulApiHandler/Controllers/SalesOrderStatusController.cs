using Contracts.ILog;
using Contracts.IServices;
using DTO.Output.Data;
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
        public async Task<IActionResult> GetAllSalesOrderStatuses()
        {
            IEnumerable<SalesOrderStatusDto> salesOrderStatusDtos = await _serviceManager.SalesOrderStatus.GetAllAsync();
            return Ok(salesOrderStatusDtos);
        }

        [HttpGet]
        [Route("salesorderstatuses/{salesOrderStatusId:guid}", Name = "GetSalesOrderStatusById")]
        public async Task<IActionResult> GetSalesOrderStatusById(Guid salesOrderStatusId)
        {
            SalesOrderStatusDto? salesOrderStatusDto = await _serviceManager.SalesOrderStatus.GetOneByIdAsync(salesOrderStatusId);
            if (salesOrderStatusDto == null)
            {
                return NotFound();
            }
            return Ok(salesOrderStatusDto);
        }

    }
}
