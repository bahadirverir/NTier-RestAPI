using System.Reflection;
using System.Text;
using Entities.Models;
using Entities.RequestFeatures;
using System.Linq.Dynamic.Core;

namespace Repositories.RepositoryExtensions
{ 
    public static class EmployeeRepositoryExtension
    {
        public static IQueryable<Employee> FilterEmployees(this IQueryable<Employee> employees, EmployeeParameters parameters)
        {
            if (parameters.MinSalary.HasValue)
                employees = employees.Where(e => e.Salary >= parameters.MinSalary.Value);

            if (parameters.MaxSalary.HasValue)
                employees = employees.Where(e => e.Salary <= parameters.MaxSalary.Value);

            return employees;
        }

        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string? firstName, string? lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                var fn = firstName.Trim().ToLower();
                employees = employees.Where(e => e.FirstName.ToLower().Contains(fn));
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                var ln = lastName.Trim().ToLower();
                employees = employees.Where(e => e.LastName.ToLower().Contains(ln));
            }
            
            return employees;
        }

        public static IQueryable<Employee> Sort(this IQueryable<Employee> employees, string? orderByQueryStirng)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryStirng))
                return employees.OrderBy(e => e.EmployeeID);
            
            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Employee>(orderByQueryStirng);

            if(orderQuery is null)
                return employees.OrderBy(e => e.EmployeeID);
            
            return employees.OrderBy(orderQuery);
        }
    }
}
