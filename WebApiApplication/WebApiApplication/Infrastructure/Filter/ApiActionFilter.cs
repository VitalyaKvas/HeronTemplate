using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiApplication.Infrastructure.ApiControllers;

namespace WebApiApplication.Infrastructure.Filter
{
    public class ApiActionFilter : ActionFilterAttribute
    {
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
            }
            else
            {
                apiResponse.Data = result.Value;
            }

            context.Result = new JsonResult(apiResponse);
        }
    }
}
