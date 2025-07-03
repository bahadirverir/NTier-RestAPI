using Entities.DataTransferObjects;
using Services.Abstract;
using Services.Concrete;

namespace WebApi.ServiceExtensions 
{ 
    public static class DataShaperServiceExtension
    {
        public static void ConfigureDataShaper(this IServiceCollection services)
        {
            services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
            services.AddScoped<IDataShaper<DepartmentDto>, DataShaper<DepartmentDto>>();
            services.AddScoped<IDataShaper<JobDto>, DataShaper<JobDto>>();
        }
    }
}
