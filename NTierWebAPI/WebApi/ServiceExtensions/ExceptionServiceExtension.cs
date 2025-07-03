using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace WebApi.ServiceExtensions 
{ 
    public static class ExceptionServiceExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            RefreshTokenBadRequestException => StatusCodes.Status400BadRequest, 
                            NotFoundException => StatusCodes.Status404NotFound,
                            DepartmentDuplicateException => StatusCodes.Status409Conflict,
                            JobDuplicateException => StatusCodes.Status409Conflict,
                            EmployeeDuplicateException => StatusCodes.Status409Conflict,
                            UnSupportedMediaTypeException => StatusCodes.Status415UnsupportedMediaType,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        await context.Response.WriteAsync(new ErrorDetails(){
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
