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
    [Route("api/employeestatuses")]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public EmployeeStatusController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<EmployeeStatusDto> employeeStatusDtos = _serviceManager.EmployeeStatus.GetAll(isTrackChanges: false);
            return Ok(employeeStatusDtos);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                EmployeeStatusDto? employeeStatusDto = _serviceManager.EmployeeStatus.GetById(isTrackChanges: false, id);
                if (employeeStatusDto == null)
                {
                    return NotFound();
                }
                return Ok(employeeStatusDto);
            }
            catch (Exception ex)
            {
                _logService.LogError($"Something wrong: {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
