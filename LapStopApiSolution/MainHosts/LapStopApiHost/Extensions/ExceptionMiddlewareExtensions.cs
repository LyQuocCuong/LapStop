using Contracts.ILog;
using Microsoft.AspNetCore.Diagnostics;
using Shared.CustomedExceptions;
using Shared.ErrorModels;

namespace LapStopApiHost.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILogService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    //Original Code: Always return 500 error -> NOT USE contextFeature
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                        
                    if (contextFeature != null)
                    {
                        //Custom Code:
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException404 => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            //Original Code: Message = "Internal Server Error.",
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
