namespace RestfulApiHandler.ControllersVer2
{
    public sealed class BrandVer02Controller : AbstractApiVer02Controller
    {
        public BrandVer02Controller(ILogService logService, IDomainServices domainServices) 
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
