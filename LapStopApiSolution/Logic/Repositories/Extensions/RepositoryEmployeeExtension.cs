using Domains.Models;
using DTO.Input.FromQuery.Parameters;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Repositories.Extensions
{
    internal static class RepositoryEmployeeExtension
    {
        public static IQueryable<Employee> FilterAgeExt(this IQueryable<Employee> employees, EmployeeParameter parameter)
        {
            return employees.Where(e => DateTime.Now.Year - e.DOB.Year >= parameter.MinAge &&
                                        DateTime.Now.Year - e.DOB.Year <= parameter.MaxAge);
        }

        public static IQueryable<Employee> SearchExt(this IQueryable<Employee> employees, EmployeeParameter parameter)
        {
            if (string.IsNullOrEmpty(parameter.SearchTerm))
            {
                return employees;
            }
            string lowerCaseTerm = parameter.SearchTerm.ToLower();

            return employees.Where(e => e.FirstName.ToLower().Contains(lowerCaseTerm) ||
                                        e.LastName.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Employee> OrderByExt(this IQueryable<Employee> employees, 
                                                           EmployeeParameter parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter.OrderBy))   // check NULL
            {
                return employees.OrderBy(e => e.EmployeeCode);  // DEFAULT
            }
            
            // Get all properties of Employee
            var propertyInfos = typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            // "firstName, lastName desc" -> [firstName], [lastName]
            var orderParams = parameter.OrderBy.Split(',');

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
                if (objectProperty == null) // Invalid PropName
                {
                    continue;
                }

                // default -> ascending
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
                // "firstName, lastName desc" --> "firstName ascending, lastName descending,"
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))          // check NULL
            {
                return employees.OrderBy(e => e.EmployeeCode);  // DEFAULT - OrderBy of LINQ
            }
            return employees.OrderBy(orderQuery); // OrderBy of "System.Linq.Dynamic.Core" 
        }
    }
}
