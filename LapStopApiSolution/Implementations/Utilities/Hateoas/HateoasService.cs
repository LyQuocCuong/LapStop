using Common.Models.Links;
using Contracts.Utilities.Hateoas;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Utilities.Hateoas
{
    public abstract class HateoasService<TAppliedModel> : IHateoasService<TAppliedModel>
    {
        public abstract List<LinkItemModel> GenerateHateoasLinks(HttpContext httpContext, TAppliedModel dataModel);

        private static bool ShouldExecuteHateoas(HttpContext httpContext)
        {
            if (httpContext != null &&
                httpContext.Items["AcceptHeaderMediaType"] != null)
            {
                var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];
                return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas",
                            StringComparison.InvariantCultureIgnoreCase);
            }
            return false;
        }

        public IEnumerable<TAppliedModel> Execute(HttpContext httpContext, IEnumerable<TAppliedModel> dataModelCollection)
        {
            if (dataModelCollection != null && dataModelCollection.Any() && 
                typeof(TAppliedModel).GetProperty("Links") != null)
            {
                List<TAppliedModel> dataModelList = dataModelCollection.ToList();
                if (HateoasService<TAppliedModel>.ShouldExecuteHateoas(httpContext))
                {
                    foreach (var dataModel in dataModelList)
                    {
                        if (dataModel != null)
                        {
                            // HATEOAS Model => ShapedModel + Add("Links")
                            List<LinkItemModel> hateoasLinks = GenerateHateoasLinks(httpContext, dataModel);
                            dataModel!.GetType().GetProperty("Links")!.SetValue(dataModel, hateoasLinks);
                        }
                    }
                }
                return dataModelList;
            }
            return dataModelCollection;
        }

        public TAppliedModel Execute(HttpContext httpContext, TAppliedModel dataModel)
        {
            if (dataModel != null && typeof(TAppliedModel).GetProperty("Links") != null &&
                HateoasService<TAppliedModel>.ShouldExecuteHateoas(httpContext))
            {
                // HATEOAS Model => ShapedModel + Add("Links")
                List<LinkItemModel> hateoasLinks = GenerateHateoasLinks(httpContext, dataModel);
                dataModel!.GetType().GetProperty("Links")!.SetValue(dataModel, hateoasLinks);
            }
            return dataModel;
        }
    }
}
