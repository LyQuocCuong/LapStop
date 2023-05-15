using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RestfulApiHandler.Extensions
{
    public static class ModelStateExt
    {
        public static void AddToModelStateExt(this ValidationResult result, 
                                              ModelStateDictionary modelState)
        {
            foreach(var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
