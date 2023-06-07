using Microsoft.AspNetCore.Mvc.Filters;

namespace RestfulApiHandler.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public ValidationFilterAttribute() { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //throw new NotImplementedException();
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            var param = context.ActionArguments
                               .FirstOrDefault(arg => arg.Value.ToString().Contains("Dto")).Value;
            if (param is null)
            {
                context.Result = new BadRequestObjectResult(CommonFunctions.DisplayErrors.ReturnNullObjectMessage(nameof(param)));
                return;
            }

            if (context.ModelState.IsValid == false)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
