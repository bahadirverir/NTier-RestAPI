using System.Linq.Dynamic.Core;
using Entities.Models;

namespace Repositories.RepositoryExtensions
{
    public static class DepartmentRepositoryExtension
    {
        public static IQueryable<Department> Search(this IQueryable<Department> departments, string? departmentName)
        {
            if (!string.IsNullOrWhiteSpace(departmentName))
            {
                var dpname = departmentName.Trim().ToLower();
                departments = departments.Where(d => d.DepartmentName.ToLower().Contains(dpname));
            }

            return departments;
        }

        public static IQueryable<Department> Sort(this IQueryable<Department> departments, string? orderByQueryStirng)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryStirng))
                return departments.OrderBy(d => d.DepartmentID);
            
            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Department>(orderByQueryStirng);

            if(orderQuery is null)
                return departments.OrderBy(d => d.DepartmentID);
            
            return departments.OrderBy(orderQuery);
        }
    }
}
