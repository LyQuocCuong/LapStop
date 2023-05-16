using Contracts.IDataShaper;
using Shared.CustomModels.DynamicObjects;
using System.Reflection;

namespace Services.DataShaping
{
    public class DataShaper<TModel> : IDataShaper<TModel> where TModel : class
    {
        public PropertyInfo[] propertyInfos { get; set; }   

        public DataShaper()
        {
            // get ALL props (DEFAULT)
            propertyInfos = typeof(TModel).GetProperties(BindingFlags.Public | 
                                                         BindingFlags.Instance);
        }

        public IEnumerable<ShapedModel> ShapeData(IEnumerable<TModel> models, 
                                                    string fieldsStr)
        {
            var requiredProperties = GetRequiredProperties(fieldsStr);
            return FetchData(models, requiredProperties);
        }

        public ShapedModel ShapeData(TModel model, string fieldsStr)
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

        private IEnumerable<ShapedModel> FetchData(IEnumerable<TModel> models, 
                                                     IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedData = new List<ShapedModel>();
            foreach (var model in models)
            {
                var shapedObject = FetchDataForEntity(model, requiredProperties);
                shapedData.Add(shapedObject);
            }
            return shapedData;
        }

        private ShapedModel FetchDataForEntity(TModel model, IEnumerable<PropertyInfo> requiredProperties)
        {
            var shapedObject = new ShapedModel();
            foreach (var property in requiredProperties) 
            { 
                var objectPropertyValue = property.GetValue(model); 
                shapedObject.TryAdd(property.Name, objectPropertyValue); 
            }
            return shapedObject;
        }
    }
}
