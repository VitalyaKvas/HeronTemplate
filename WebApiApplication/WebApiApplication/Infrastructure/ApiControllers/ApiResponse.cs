using System.Collections.Generic;

namespace WebApiApplication.Infrastructure.ApiControllers
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> ErrorsValidation { get; set; }
        public string ErrorMessages { get; set; }

#if !DEBUG
        [Newtonsoft.Json.JsonIgnore]
#endif
        public string StackTrace { get; set; }

        public ApiResponse() { }
    }
}
