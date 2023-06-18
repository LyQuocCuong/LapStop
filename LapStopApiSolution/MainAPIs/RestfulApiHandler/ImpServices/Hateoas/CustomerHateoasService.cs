using Common.Models.Links;
using ImpServices.Hateoas;
using Microsoft.AspNetCore.Http;

namespace RestfulApiHandler.ImpServices.Hateoas
{
    public sealed class CustomerHateoasService : HateoasService<CustomerDto>
    {
        private readonly LinkGenerator _linkGenerator;

        public CustomerHateoasService(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public override List<LinkItemModel> GenerateHateoasLinks(HttpContext httpContext, CustomerDto dataModel)
        {
            List<LinkItemModel> hateoasLinks = new List<LinkItemModel>();
            if (_linkGenerator != null)
            {
                Guid id = dataModel.Id;
                hateoasLinks.Add(
                    new LinkItemModel(
                        method: "GET",
                        rel: "self",
                        href: _linkGenerator!.GetUriByAction(httpContext, "GetCustomerById", values: new { @customerId = id }))
                );
                hateoasLinks.Add(
                    new LinkItemModel(
                        method: "PUT",
                        rel: "update",
                        href: _linkGenerator!.GetUriByAction(httpContext, "UpdateCustomer", values: new { @customerId = id }))
                );
                hateoasLinks.Add(
                    new LinkItemModel(
                        method: "DELETE",
                        rel: "delete",
                        href: _linkGenerator!.GetUriByAction(httpContext, "DeleteCustomer", values: new { @customerId = id }))
                );
            }
            return hateoasLinks;
        }
    }
}
