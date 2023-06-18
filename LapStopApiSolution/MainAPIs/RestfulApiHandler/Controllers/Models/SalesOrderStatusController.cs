﻿namespace RestfulApiHandler.Controllers.Models
{
    [ApiController]
    [Route("api")]
    public class SalesOrderStatusController : RootController
    {
        public SalesOrderStatusController(ILogService logService,
                                          IServiceManager serviceManager)
                                   : base(logService, serviceManager)
        {
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