﻿using Common.Models.DynamicObjects;
using Common.Models.HATEOAS;
using Contracts.DataShaper;
using DTO.Output.Data;
using LogicServices.Hateoas.UsingExpandoForXmlObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace RestfulApiHandler.HATEOAS
{
    public class BrandHateoasService : HateoasService<BrandDto>
    {
        private readonly LinkGenerator _linkGenerator;

        public BrandHateoasService(LinkGenerator linkGenerator,
                                   IDataShaperService<BrandDto, ExpandoForXmlObject> dataShaperService)
            : base (dataShaperService) 
        {
            _linkGenerator = linkGenerator;
        }

        public override bool ShouldExecuteHateoas(HttpContext httpContext)
        {
            //var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"]; 
            //return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase); 
            return true;
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