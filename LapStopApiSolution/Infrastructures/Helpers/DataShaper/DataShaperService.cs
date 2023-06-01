using Common.Models.DynamicObjects;
using Contracts.IDataShaper;
using System.Reflection;

namespace Helpers.DataShaper
{
    public class DataShaperService<TModel> : IDataShaperService<TModel> where TModel : class
    {
        public PropertyInfo[] propertyInfos { get; set; }   

        public DataShaperService()
        {
            // get ALL props (DEFAULT)
            propertyInfos = typeof(TModel).GetProperties(BindingFlags.Public | 
                                                         BindingFlags.Instance);
        }

        public IEnumerable<DynamicModel> ShapingData(IEnumerable<TModel> models, string fieldsStr)
        {
            var requiredProperties = GetRequiredProperties(fieldsStr);
            return FetchData(models, requiredProperties);
        }

        public DynamicModel ShapingData(TModel model, string fieldsStr)
        {
            var requiredProperties = GetRequiredProperties(fieldsStr);
            return FetchDataForEntity(model, requiredProperties);
        }

        private IEnumerable<PropertyInfo> GetRequiredProperties(string fieldsString)
        {
            var requiredProperties = new List<PropertyInfo>();
            if (!string.IsNullOrWhiteSpace(fieldsString))
            {
                var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
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

        private IEnumerable<DynamicModel> FetchData(IEnumerable<TModel> models, 
                                                     IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<DynamicModel>();
            foreach (var model in models)
            {
                var shapedObject = FetchDataForEntity(model, requiredProperties);
                shapedData.Add(shapedObject);
            }
            return shapedData;
        }

        private DynamicModel FetchDataForEntity(TModel model, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedObject = new DynamicModel();
            foreach (var property in requiredProperties) 
            { 
                var objectPropertyValue = property.GetValue(model); 
                shapedObject.TryAdd(property.Name, objectPropertyValue); 
            }
            return shapedObject;
        }
    }
}
