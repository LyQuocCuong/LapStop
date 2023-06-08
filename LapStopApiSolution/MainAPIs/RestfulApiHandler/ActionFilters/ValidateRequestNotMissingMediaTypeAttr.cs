using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

namespace RestfulApiHandler.ActionFilters
{
    public class ValidateRequestNotMissingMediaTypeAttr : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var acceptHeaderPresent = context.HttpContext.Request.Headers.ContainsKey("Accept");
            if (acceptHeaderPresent == false)
            {
                context.Result = new BadRequestObjectResult($"Accept header is missing.");
                return;
            }

            var mediaType = context.HttpContext.Request.Headers["Accept"].FirstOrDefault();

            if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue? outMediaType))
            {
                context.Result = new BadRequestObjectResult($"Media Type not present. " +
                    $"Please add Accept header with the required media type.");
                return;
            }

            context.HttpContext.Items.Add("AcceptHeaderMediaType", outMediaType);

        }
    }
}
