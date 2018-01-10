using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using WebApiApplication.Infrastructure.ApiControllers;

namespace WebApiApplication.Infrastructure.Filter
{
    public class ApiActionFilter : ActionFilterAttribute
    {
        private readonly ILogger logger;

        public ApiActionFilter(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger("ApiActionFilter");
        }

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
