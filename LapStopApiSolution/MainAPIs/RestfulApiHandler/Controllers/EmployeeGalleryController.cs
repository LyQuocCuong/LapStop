using Contracts.ILog;
using Contracts.IServices;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;

namespace RestfulApiHandler.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmployeeGalleryController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IServiceManager _serviceManager;

        public EmployeeGalleryController(ILogService logService, IServiceManager serviceManager)
        {
            _logService = logService;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("employees/{id:guid}/galleries")]
        public IActionResult GetByEmployeeId(Guid id)
        {
            List<EmployeeGalleryDto> employeeGalleryDtos = _serviceManager.EmployeeGallery.GetByEmployeeId(isTrackChanges: false, id);
            return Ok(employeeGalleryDtos);
        }

    }
}
