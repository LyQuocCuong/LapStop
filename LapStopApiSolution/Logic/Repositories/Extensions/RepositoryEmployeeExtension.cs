using Domains.Models;
using DTO.Input.FromQuery.Parameters;
using Repositories.Extensions.Utility;
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

            string orderQuery = OrderQueryBuilder.CreateOrderQueryFor<Employee>(parameter.OrderBy);
            
            if (string.IsNullOrWhiteSpace(orderQuery))          // check NULL
            {
                return employees.OrderBy(e => e.EmployeeCode);  // DEFAULT - OrderBy of LINQ
            }
            return employees.OrderBy(orderQuery); // OrderBy of "System.Linq.Dynamic.Core" 
        }
    }
}
