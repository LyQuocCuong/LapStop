using Common.Models.Links;
using RestfulApiHandler.Models;

namespace RestfulApiHandler.Roots
{
    [Route("/api")]
    [ApiController]
    public sealed class RootDocumentController : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public RootDocumentController(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType != null &&
                mediaType!.Contains("application/api.lapstop.apiroot"))
            {
                List<LinkItemModel> rootLinks = new List<LinkItemModel>()
                {
                    new LinkItemModel(
                        method: "GET",
                        rel: "self",
                        href: _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new { })
                    )
                };

                List<RootDocumentModel> rootDocuments = new List<RootDocumentModel>()
                {
                    new RootDocumentModel("Root_Document", rootLinks)
                };
                AppendBrandRootLinks(rootDocuments);
                AppendCustomerRootLinks(rootDocuments);

                return Ok(rootDocuments);
            }
            return NoContent();
        }

        private void AppendBrandRootLinks(List<RootDocumentModel> rootDocuments)
        {
            List<LinkItemModel> links = new List<LinkItemModel>()
            {
                new LinkItemModel
                (
                    method: "GET",
                    rel: "brands",
                    href: _linkGenerator.GetUriByName(HttpContext, "GetAllBrands", new { })
                ),
                new LinkItemModel
                (
                    method: "POST",
                    rel: "create_brand",
                    href: _linkGenerator.GetUriByName(HttpContext, "CreateBrand", new { })
                ),
                new LinkItemModel
                (
                    method: "HEAD",
                    rel: "head",
                    href: _linkGenerator.GetUriByName(HttpContext, "GetAllBrandsHead", new { })
                ),
                new LinkItemModel
                (
                    method: "OPTIONS",
                    rel: "options",
                    href: _linkGenerator.GetUriByName(HttpContext, "GetBrandOptions", new { })
                ),
            };

            rootDocuments.Add(new RootDocumentModel("Brands", links));
        }

        private void AppendCustomerRootLinks(List<RootDocumentModel> rootDocuments)
        {
            List<LinkItemModel> links = new List<LinkItemModel>()
            {
                new LinkItemModel
                (
                    method: "GET",
                    rel: "customer",
                    href: _linkGenerator.GetUriByName(HttpContext, "GetAllCustomers", new { })
                ),
                new LinkItemModel
                (
                    method: "POST",
                    rel: "create_customer",
                    href: _linkGenerator.GetUriByName(HttpContext, "CreateCustomer", new { })
                ),
                new LinkItemModel
                (
                    method: "HEAD",
                    rel: "head",
                    href: _linkGenerator.GetUriByName(HttpContext, "GetAllCustomersHead", new { })
                ),
                new LinkItemModel
                (
                    method: "OPTIONS",
                    rel: "options",
                    href: _linkGenerator.GetUriByName(HttpContext, "GetCustomerOptions", new { })
                ),
            };

            rootDocuments.Add(new RootDocumentModel("Customers", links));
        }

    }
}
