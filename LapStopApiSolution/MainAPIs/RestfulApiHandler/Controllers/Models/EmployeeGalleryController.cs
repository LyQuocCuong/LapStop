namespace RestfulApiHandler.Controllers.Models
{
    [ApiController]
    [Route("api")]
    public class EmployeeGalleryController : RootController
    {
        public EmployeeGalleryController(ILogService logService,
                                         IServiceManager serviceManager)
                                  : base(logService, serviceManager)
        {
        }

        [HttpGet]
        [Route("employees/{employeeId:guid}/galleries", Name = "GetAllEmployeeGalleriesByEmployeeId")]
        public async Task<IActionResult> GetAllEmployeeGalleriesByEmployeeId(Guid employeeId)
        {
            IEnumerable<EmployeeGalleryDto> employeeGalleryDtos = await _serviceManager.EmployeeGallery.GetAllByEmployeeIdAsync(employeeId);
            return Ok(employeeGalleryDtos);
        }

    }
}
