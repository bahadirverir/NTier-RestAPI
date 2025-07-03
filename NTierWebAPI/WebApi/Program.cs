using Repositories.Abstract;
using Repositories.Concrete;
using Services.Abstract;
using Services.Concrete;
using WebApi.ServiceExtensions;
using WebApi.AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.CsvFormatter;
using Microsoft.AspNetCore.Authorization;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers(config =>
{
    config.OutputFormatters.Add(new CsvOutputFormatter());    
    config.RespectBrowserAcceptHeader = true; 
    config.ReturnHttpNotAcceptable = true; 
})
.AddXmlSerializerFormatters(); 

builder.Services.AddControllers() 
    .AddApplicationPart(typeof(Presentation.Controllers.EmployeesController).Assembly) 
    .AddApplicationPart(typeof(Presentation.Controllers.DepartmentsController).Assembly) 
    .AddApplicationPart(typeof(Presentation.Controllers.JobsController).Assembly);

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<ICustomAuthenticationService, CustomAuthenticationService>();

builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationMiddlewareResultHandler>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.ConfigureSwagger(); 
builder.Services.ConfigureMySqlContext(builder.Configuration); 
builder.Services.ConfigureCors(); 
builder.Services.ConfigureDataShaper(); 
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

var app = builder.Build(); 

app.ConfigureExceptionHandler(); 

app.UseCors("CorsPolicy");

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllers();

app.Run();