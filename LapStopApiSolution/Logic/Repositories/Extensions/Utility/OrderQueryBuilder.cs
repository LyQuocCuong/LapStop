using Domains.Models;
using System.Reflection.Metadata;
using System.Reflection;
using System.Text;

namespace Repositories.Extensions.Utility
{
    public static class OrderQueryBuilder
    {
        // INPUT Syntax: "firstName, lastName desc"
        public static string CreateOrderQueryFor<TModel>(string orderByQueryStr)
        {
            // Get all properties of TModel
            var propertyInfos = typeof(TModel).GetProperties(BindingFlags.Public | 
                                                             BindingFlags.Instance);

            // "firstName, lastName desc" -> [firstName], [lastName]
            var orderParams = orderByQueryStr.Split(',');

            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))   // " , lastName desc" -> [''], [lastName]
                {
                    continue;
                }

                // "firstName" --> "firstName"
                // "lastName desc" --> "lastName"
                var propertyNameFromQuery = param.Split(" ")[0];

                var objectProperty = propertyInfos.FirstOrDefault(
                                        pi => pi.Name.Equals(propertyNameFromQuery,
                                                             StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null) // INVALID PropName
                {
                    continue;
                }

                // default -> ascending
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
                // "firstName, lastName desc" --> "firstName ascending, lastName descending,"
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return orderQuery;
        }
    }
}
