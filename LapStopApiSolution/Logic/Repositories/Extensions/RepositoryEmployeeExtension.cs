using Repositories.Extensions.Utility;

namespace Repositories.Extensions
{
    internal static class RepositoryEmployeeExtension
    {
        public static IQueryable<Employee> FilterAgeExt(this IQueryable<Employee> employees, EmployeeRequestParam parameter)
        {
            return employees.Where(e => DateTime.Now.Year - e.DOB.Year >= parameter.MinAge &&
                                        DateTime.Now.Year - e.DOB.Year <= parameter.MaxAge);
        }

        public static IQueryable<Employee> SearchExt(this IQueryable<Employee> employees, EmployeeRequestParam parameter)
        {
            if (string.IsNullOrEmpty(parameter.SearchTerm))
            {
                return employees;
            }
            string lowerCaseTerm = parameter.SearchTerm.ToLower();

            return employees.Where(e => (e.FirstName != null && e.FirstName.ToLower().Contains(lowerCaseTerm)) ||
                                        (e.LastName != null && e.LastName.ToLower().Contains(lowerCaseTerm)));
        }

        public static IQueryable<Employee> OrderByExt(this IQueryable<Employee> employees, 
                                                           EmployeeRequestParam parameter)
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
