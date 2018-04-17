using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebApiApplication.Infrastructure.ApiControllers;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

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
            {
                context.Result = new JsonResult(apiResponse);
                return;
            }

            if (result.StatusCode != null && result.StatusCode != StatusCodes.Status200OK)
            {
                switch (result.Value)
                {
                    case ValueEnumerable list:
                        {
                            if (apiResponse.ErrorsValidation == null)
                                apiResponse.ErrorsValidation = new List<string>();

                            foreach (var modelState in list)
                                foreach (var error in modelState.Errors)
                                {
                                    apiResponse.ErrorsValidation.Add(error.ErrorMessage);
                                }

                            apiResponse.ErrorMessages = "Values are not valid.";

                        } break;
                    case IEnumerable<IdentityError> list:
                        {
                            if (apiResponse.ErrorsValidation == null)
                                apiResponse.ErrorsValidation = new List<string>();

                            foreach (var error in list)
                            {
                                apiResponse.ErrorsValidation.Add(error.Description);
                            }

                            apiResponse.ErrorMessages = "Values are not valid.";

                        } break;
                    default:
                        {
                            apiResponse.ErrorMessages = result.Value.ToString();
                        } break;
                }
                
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
