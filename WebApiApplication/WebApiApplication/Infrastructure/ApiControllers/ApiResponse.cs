using System.Collections.Generic;

namespace WebApiApplication.Infrastructure.ApiControllers
{
    /// <summary>
    /// Wrap for all response from the server
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Data that returned action
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// HTTP response status codes
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// This list contains messages about all errors validation data.
        /// </summary>
        public List<string> ErrorsValidation { get; set; }

        /// <summary>
        /// Contains messages about unsuccessful / impossible actions on the server, as well exceptions message
        /// </summary>
        public string ErrorMessages { get; set; }

        /// <summary>
        /// Present the full exception information (including the inner stack trace) in text.
        /// Only for DEBUG
        /// </summary>
#if !DEBUG
        [Newtonsoft.Json.JsonIgnore]
#endif
        public string StackTrace { get; set; }

        /// <summary>
        /// Creates a new instance with the given value.
        /// </summary>
        public ApiResponse()
        {
            StatusCode = 200;
        }
    }
}
