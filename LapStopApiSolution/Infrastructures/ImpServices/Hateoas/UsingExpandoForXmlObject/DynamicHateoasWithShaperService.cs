using Common.Models.DynamicObjects;
using Common.Models.Links;
using Contracts.DataShaper;
using Contracts.Hateoas;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace ImpServices.Hateoas.UsingExpandoForXmlObject
{
    public abstract class DynamicHateoasWithShaperService<TAppliedModel> : IHateoasWithShaperService<TAppliedModel, ExpandoForXmlObject>
    {
        private readonly string _coreProperties;

        public DynamicHateoasWithShaperService(string coreProperties = "Id")
        {
            _coreProperties = coreProperties;
        }

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

        private string AppendCoreProperties(string shapingPropsStr)
        {
            if (!string.IsNullOrEmpty(shapingPropsStr))
            {
                shapingPropsStr = string.Concat(_coreProperties, ",", shapingPropsStr);
            }
            return shapingPropsStr;
        }

        private ExpandoForXmlObject AppendHateoasLinks(HttpContext httpContext, TAppliedModel dataModel, ExpandoForXmlObject shapedModel)
        {
            // HATEOAS Model => ShapedModel + Add("Links")
            List<LinkItemModel> hateoasLinks = GenerateHateoasLinks(httpContext, dataModel);
            shapedModel.TryAdd("Links", hateoasLinks);
            return shapedModel;
        }

        public IEnumerable<ExpandoForXmlObject> Execute(
            IDataShaperService<TAppliedModel, ExpandoForXmlObject> dataShaperService,
            HttpContext httpContext, 
            IEnumerable<TAppliedModel> dataModelCollection, string shapingPropsStr)
        {
            List<ExpandoForXmlObject> hateoasModels = new List<ExpandoForXmlObject>();
            if (DynamicHateoasWithShaperService<TAppliedModel>.ShouldExecuteHateoas(httpContext))
            {
                // append the CoreProperties before executing Shaping
                shapingPropsStr = AppendCoreProperties(shapingPropsStr);
                foreach (var dataModel in dataModelCollection)
                {
                    ExpandoForXmlObject shapedModel = dataShaperService.Execute(dataModel,shapingPropsStr);
                    shapedModel = AppendHateoasLinks(httpContext, dataModel, shapedModel);
                    hateoasModels.Add(shapedModel);
                }
            }
            else
            {
                foreach (var dataModel in dataModelCollection)
                {
                    ExpandoForXmlObject shapedModelWithoutLinks = dataShaperService.Execute(dataModel, shapingPropsStr);
                    hateoasModels.Add(shapedModelWithoutLinks);
                }
            }
            return hateoasModels;
        }

        public ExpandoForXmlObject Execute(
            IDataShaperService<TAppliedModel, ExpandoForXmlObject> dataShaperService,
            HttpContext httpContext, TAppliedModel dataModel, string shapingPropsStr)
        {
            if (DynamicHateoasWithShaperService<TAppliedModel>.ShouldExecuteHateoas(httpContext))
            {
                // append the CoreProperties before executing Shaping Data
                shapingPropsStr = AppendCoreProperties(shapingPropsStr);
                ExpandoForXmlObject shapedModel = dataShaperService.Execute(dataModel,shapingPropsStr);
                shapedModel = AppendHateoasLinks(httpContext, dataModel, shapedModel);
                return shapedModel;
            }
            return dataShaperService.Execute(dataModel, shapingPropsStr); ;
        }
    }
}
