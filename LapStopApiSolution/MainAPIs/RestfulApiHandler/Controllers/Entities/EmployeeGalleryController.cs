namespace RestfulApiHandler.Controllers.Entities
{
    [ApiController]
    [Route("api")]
    public class EmployeeGalleryController : AbstractApiControllerVer01
    {
        public EmployeeGalleryController(ILogService logService,
                                IDomainServices domainServices)
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("employees/{employeeId:guid}/galleries", Name = "GetAllEmployeeGalleriesByEmployeeId")]
        public async Task<IActionResult> GetAllEmployeeGalleriesByEmployeeId(Guid employeeId)
        {
            IEnumerable<EmployeeGalleryDto> employeeGalleryDtos = await EntityServices.EmployeeGallery.GetAllByEmployeeIdAsync(employeeId);
            return Ok(employeeGalleryDtos);
        }

    }
}
