using Common.Models.DynamicObjects;
using Common.Models.Hateoas;
using Contracts.DataShaperService;
using Contracts.HateoasService;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace LogicServices.Hateoas.UsingExpandoForXmlObject
{
    public abstract class HateoasService<TAppliedModel> : IHateoasService<TAppliedModel, ExpandoForXmlObject>
    {
        private readonly string _coreProperties;
        private readonly IDataShaperService<TAppliedModel, ExpandoForXmlObject> _dataShaperService;

        public HateoasService(IDataShaperService<TAppliedModel, ExpandoForXmlObject> dataShaperService,
                                  string coreProperties = "Id")
        {
            _dataShaperService = dataShaperService;
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

        public IEnumerable<ExpandoForXmlObject> ExecuteHateoas(HttpContext httpContext, IEnumerable<TAppliedModel> dataModelCollection, string requiredPropsStr)
        {
            List<ExpandoForXmlObject> hateoasModels = new List<ExpandoForXmlObject>();
            if (HateoasService<TAppliedModel>.ShouldExecuteHateoas(httpContext))
            {
                // append the CoreProperties before executing Shaping
                if (!string.IsNullOrEmpty(requiredPropsStr))
                {
                    requiredPropsStr = string.Concat(_coreProperties, ",", requiredPropsStr);
                }
                foreach (var dataModel in dataModelCollection)
                {
                    ExpandoForXmlObject shapedModel = _dataShaperService.ExecuteShapingData(dataModel, 
                                                                                        requiredPropsStr);

                    // HATEOAS Model => ShapedModel + Add("Links")
                    List<LinkItemModel> hateoasLinks = GenerateHateoasLinks(httpContext, dataModel);
                    shapedModel.TryAdd("Links", hateoasLinks);

                    hateoasModels.Add(shapedModel);
                }
            }
            else
            {
                foreach (var dataModel in dataModelCollection)
                {
                    ExpandoForXmlObject shapedModelWithoutLinks = _dataShaperService
                                                .ExecuteShapingData(dataModel, requiredPropsStr);
                    hateoasModels.Add(shapedModelWithoutLinks);
                }
            }
            return hateoasModels;
        }

        public ExpandoForXmlObject ExecuteHateoas(HttpContext httpContext, TAppliedModel dataModel, string requiredPropsStr)
        {
            if (HateoasService<TAppliedModel>.ShouldExecuteHateoas(httpContext))
            {
                // append the CoreProperties before executing Shaping
                if (!string.IsNullOrEmpty(requiredPropsStr))
                {
                    requiredPropsStr = string.Concat(_coreProperties, ",", requiredPropsStr);
                }

                ExpandoForXmlObject shapedModel = _dataShaperService.ExecuteShapingData(dataModel, 
                                                                                    requiredPropsStr);

                // HATEOAS Model => ShapedModel + Add("Links")
                List<LinkItemModel> hateoasLinks = GenerateHateoasLinks(httpContext, dataModel);
                shapedModel.TryAdd("Links", hateoasLinks);

                return shapedModel;
            }
            return _dataShaperService.ExecuteShapingData(dataModel, requiredPropsStr); ;
        }
    }
}
