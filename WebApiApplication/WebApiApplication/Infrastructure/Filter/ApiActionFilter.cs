using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using WebApiApplication.Infrastructure.ApiControllers;

namespace WebApiApplication.Infrastructure.Filter
{
    /// <summary>
    /// Filter to catch all Action and wrap these data in a beautiful view.
    /// </summary>
    public class ApiActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;

        /// <summary>
        /// Creates a new instance with the given value.
        /// </summary>
        /// <param name="loggerFactory">ILoggerFactory</param>
        public ApiActionFilter(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger("ApiActionFilter");
        }

        /// <summary>
        /// Called after the action executes, before the action result.
        /// And modifies the response.
        /// </summary>
        /// <param name="context">ActionExecutedContext</param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var apiResponse = new ApiResponse();

            var result = context.Result as ObjectResult;
            if (result == null || result.Value == null)
                return;

            if (result.StatusCode != null)
            {
                apiResponse.ErrorMessages = result.Value.ToString();
                apiResponse.StatusCode = result.StatusCode.Value;

                logger.LogError($"ActionDescriptor: {context.ActionDescriptor.DisplayName}, StatusCode: {apiResponse.StatusCode}, ErrorMessages: {apiResponse.ErrorMessages}.");
            }
            else
            {
                apiResponse.Data = result.Value;
            }

            context.Result = new JsonResult(apiResponse);
        }
    }
}
