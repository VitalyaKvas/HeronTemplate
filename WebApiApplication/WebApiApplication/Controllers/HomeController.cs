using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Infrastructure.ApiControllers;

namespace WebApiApplication.Controllers
{
    [Route("[controller]")]
    public class HomeController : ApiBaseController
    {
        [HttpGet("UrlNotFound")]
        public ActionResult UrlNotFound()
        {
            return NotFound("URL not found");
        }
    }
}
