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
        [Route("employees/{employeeId:guid}/galleries", Name = "GetAllEmployeeGalleriesByEmployeeId")]
        public IActionResult GetAllEmployeeGalleriesByEmployeeId(Guid employeeId)
        {
            List<EmployeeGalleryDto> employeeGalleryDtos = _serviceManager.EmployeeGallery.GetAllByEmployeeId(employeeId);
            return Ok(employeeGalleryDtos);
        }

    }
}
