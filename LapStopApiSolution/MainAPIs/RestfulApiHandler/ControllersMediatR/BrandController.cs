using Application.Commands.BrandCommands;
using Application.Notifications;
using Application.Queries.BrandQueries;
using MediatR;

namespace RestfulApiHandler.ControllersMediatR
{
    [Route("api/mediat/brands")]
    public sealed class BrandController : AbstractApiVer01Controller
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public BrandController(ILogService logService, 
                                IDomainServices domainServices,
                                ISender sender, IPublisher publisher) 
            : base(logService, domainServices)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteBrand(Guid id)
        { 
            await _publisher.Publish(new BrandDeletedNotification(id));
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _sender.Send(new GetAllBrandsQuery(isTracking: false));
            return Ok(brands);
        }

        [Route("{id:guid}", Name = "GetBrandByIdMediatR")]
        [HttpGet]
        public async Task<IActionResult> GetBrandById([FromRoute]Guid id)
        {
            var brand = await _sender.Send(new GetBrandByIdQuery(isTracking: false, brandId: id));
            return Ok(brand);
        }

        [Route("{id:guid}")]
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(Guid id, [FromBody]BrandForUpdateDto updateDto)
        {
            await _sender.Send(new UpdateBrandCommand(id, updateDto));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody]BrandForCreationDto creationDto)
        {
            BrandDto brandDto = await _sender.Send(new CreateBrandCommand(creationDto));
            return CreatedAtRoute("GetBrandByIdMediatR", new { id = brandDto.Id }, brandDto);
        }



    }
}
