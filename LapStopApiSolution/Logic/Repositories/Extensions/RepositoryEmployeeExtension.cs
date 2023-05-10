using Domains.Models;
using DTO.Input.FromQuery.Parameters;

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

    }
}
