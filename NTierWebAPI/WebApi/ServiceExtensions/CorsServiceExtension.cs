
namespace WebApi.ServiceExtensions
{ 
    public static class CorsServiceExtension 
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
                    .WithExposedHeaders("X-Pagination")
                );
            });
        }
    }
}
