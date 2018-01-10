using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiApplication.Infrastructure.ApiControllers;

namespace WebApiApplication.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    [Route("[controller]")]
    public class HomeController : ApiBaseController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">ILogger</param>
        public HomeController(ILogger<HomeController> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Simulates not found action
        /// </summary>
        /// <returns>Status 404 - not found</returns>
        [HttpGet("UrlNotFound")]
        public ActionResult UrlNotFound()
        {
            return NotFound("URL not found");
        }
    }
}
