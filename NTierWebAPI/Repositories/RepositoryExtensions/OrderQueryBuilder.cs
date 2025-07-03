using System.Reflection;
using System.Text;

namespace Repositories.RepositoryExtensions
{ 
    public static class OrderQueryBuilder
    {
        public static String CreateOrderQuery<T>(String orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(',');

            var propertyInfo = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();
             
            foreach(var param in orderParams)
            {
                if(string.IsNullOrWhiteSpace(param))
                    continue;
                
                var propertyFromQuery = param.Split(' ')[0];

                var objectProperty = propertyInfo
                    .FirstOrDefault(pi => pi.Name.Equals(propertyFromQuery,
                    StringComparison.InvariantCultureIgnoreCase));
                
                if(objectProperty is null)
                    continue;

                var direction = param.EndsWith("desc") ? "descending" : "ascending"; 
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}");
            }
            
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return orderQuery;
        }
    }
}
