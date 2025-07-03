using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.ActionFilters
{ 
    public class JsonFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var contentType = context.HttpContext.Request.ContentType;

            if (contentType != "application/json")
            {
                throw new UnSupportedMediaTypeException("Only 'JSON' format is accepted.");
            }

            base.OnActionExecuting(context);
        }
    }
}
