using Entities.ErrorModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.ActionFilters // ModelValidation.
{ 
    public class ModelValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.ActionArguments
                .FirstOrDefault(p => p.Value?.ToString().Contains("Dto") == true ).Value; //NullReferenceException hatasını önledik.

            if(param is null)
            {
                var errorDetails = new ErrorDetails
                {
                    StatusCode = 400,
                    Message = "Object is null!"
                };

                context.Result = new BadRequestObjectResult(errorDetails); // 400;
                return; // İşlemi durdur
            }

            if(!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState); // 422;
            }
        }
    }
}