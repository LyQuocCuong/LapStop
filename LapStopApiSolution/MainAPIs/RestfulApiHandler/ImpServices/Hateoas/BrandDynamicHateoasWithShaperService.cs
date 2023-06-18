using Common.Models.Links;
using ImpServices.Hateoas;
using ImpServices.Hateoas.UsingExpandoForXmlObject;
using Microsoft.AspNetCore.Http;

namespace RestfulApiHandler.ImpServices.Hateoas
{
    public sealed class BrandDynamicHateoasWithShaperService : DynamicHateoasWithShaperService<BrandDto>
    {
        private readonly LinkGenerator _linkGenerator;

        public BrandDynamicHateoasWithShaperService(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override List<LinkItemModel> GenerateHateoasLinks(HttpContext httpContext, BrandDto dataModel)
        {
            List<LinkItemModel> hateoasLinks = new List<LinkItemModel>();
            if (_linkGenerator != null)
            {
                Guid id = dataModel.Id;
                hateoasLinks.Add(
                    new LinkItemModel(
                        method: "GET",
                        rel: "self",
                        href: _linkGenerator!.GetUriByAction(httpContext, "GetBrandById", values: new { @brandId = id }))
                );
                hateoasLinks.Add(
                    new LinkItemModel(
                        method: "PUT",
                        rel: "update",
                        href: _linkGenerator!.GetUriByAction(httpContext, "UpdateBrand", values: new { @brandId = id }))
                );
                hateoasLinks.Add(
                    new LinkItemModel(
                        method: "DELETE",
                        rel: "delete",
                        href: _linkGenerator!.GetUriByAction(httpContext, "DeleteBrand", values: new { @brandId = id }))
                );
            }
            return hateoasLinks;
        }
    }
}
