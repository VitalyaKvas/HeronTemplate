using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebApiApplication.Infrastructure.ApiControllers;

namespace WebApiApplication.Infrastructure.Filter
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var apiResponse = new ApiResponse();

            switch (context.Exception)
            {
                case UnauthorizedAccessException ex:
                    {
                        apiResponse.ErrorMessages = "Unauthorized Access";
                        apiResponse.StatusCode = 401;
                        context.HttpContext.Response.StatusCode = 401;
                    }
                    break;

                case Exception ex:
                    {
#if !DEBUG
                        var message = "An unhandled error occurred.";                
                        string stack = null;
#else
                        var message = context.Exception.GetBaseException().Message;
                        string stack = context.Exception.StackTrace;
#endif

                        apiResponse.ErrorMessages = message;
                        apiResponse.StackTrace = stack;
                        apiResponse.StatusCode = 500;
                        context.HttpContext.Response.StatusCode = 500;
                    }
                    break;
            }

            context.Result = new JsonResult(apiResponse);
            base.OnException(context);
        }
    }
}
