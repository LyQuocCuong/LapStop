using Common.Models.DynamicObjects;
using Contracts.DataShaperService;
using System.Reflection;

namespace LogicServices.DataShaper.UsingExpandoForXmlObject
{
    public sealed class DataShaperService<TAppliedModel> : IDataShaperService<TAppliedModel, ExpandoForXmlObject>
    {
        private readonly PropertyInfo[] propertyInfos;

        public DataShaperService()
        {
            // get ALL props of TAppliedModel first (DEFAULT)
            propertyInfos = typeof(TAppliedModel).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public IEnumerable<ExpandoForXmlObject> Execute(IEnumerable<TAppliedModel> dataModels, string? requiredPropsStr)
        {
            IEnumerable<PropertyInfo> requiredPropInfos = GetRequiredPropInfos(requiredPropsStr);
            return TrimmingProps(dataModels, requiredPropInfos);
        }

        public ExpandoForXmlObject Execute(TAppliedModel dataModel, string? requiredPropsStr)
        {
            IEnumerable<PropertyInfo> requiredPropInfos = GetRequiredPropInfos(requiredPropsStr);
            return TrimmingProps(dataModel, requiredPropInfos);
        }

        private IEnumerable<PropertyInfo> GetRequiredPropInfos(string? requiredPropsStr)
        {
            var requiredProperties = new List<PropertyInfo>();
            if (!string.IsNullOrWhiteSpace(requiredPropsStr))
            {
                var fields = requiredPropsStr.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var field in fields)
                {
                    var property = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(field.Trim(),
                                                    StringComparison.InvariantCultureIgnoreCase));
                    if (property == null)
                    {
                        continue;
                    }
                    requiredProperties.Add(property);
                }
            }
            else    // DEFAULT - get ALL Props
            {
                requiredProperties = propertyInfos.ToList();
            }
            return requiredProperties;
        }

        private IEnumerable<ExpandoForXmlObject> TrimmingProps(IEnumerable<TAppliedModel> dataModelCollection, IEnumerable<PropertyInfo> requiredProperties)
        {
            List<ExpandoForXmlObject> trimmedModelList = new List<ExpandoForXmlObject>();
            foreach (var dataModel in dataModelCollection)
            {
                ExpandoForXmlObject trimmedModel = TrimmingProps(dataModel, requiredProperties);
                trimmedModelList.Add(trimmedModel);
            }
            return trimmedModelList;
        }

        private ExpandoForXmlObject TrimmingProps(TAppliedModel dataModel, IEnumerable<PropertyInfo> requiredProperties)
        {
            ExpandoForXmlObject trimmedModel = new ExpandoForXmlObject();
            foreach (var property in requiredProperties)
            {
                // Dynamic properties (following Input required properties)
                trimmedModel!.TryAdd(property.Name, property.GetValue(dataModel));
            }
            return trimmedModel;
        }
    }
}
