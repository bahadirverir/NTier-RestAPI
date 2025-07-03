using Microsoft.EntityFrameworkCore;
using Repositories;

namespace WebApi.ServiceExtensions 
{ 
    public static class DbContextServiceExtension
    {
        public static void ConfigureMySqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
    }
}
