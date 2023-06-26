namespace RestfulApiHandler.ControllersVer2
{
    [ApiVersion("2.0", Deprecated = true)]
    [ApiController]
    [Route("/api/{v:apiversion}")]
    public sealed class BrandV2Controller : AbstractController
    {
        public BrandV2Controller(ILogService logService, IDomainServices domainServices) 
            : base(logService, domainServices)
        {
        }

        [HttpGet]
        [Route("brands", Name = "GetAllBrandsV2")]
        [ServiceFilter(typeof(ValidateRequestNotMissingMediaTypeAttr))]
        public async Task<IActionResult> GetAllBrands([FromQuery] BrandRequestParam parameters)
        {
            HateoasParams<BrandRequestParam> hateoasParameters = new(HttpContext, parameters);
            PagedList<ExpandoForXmlObject> pagedResult = await EntityServices.Brand.GetAllAsync(hateoasParameters);
            Response.Headers.Add("X-PaginationV2", JsonSerializer.Serialize(pagedResult.MetaData));
            return Ok(pagedResult);
        }

    }
}
