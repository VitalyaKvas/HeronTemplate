using Microsoft.AspNetCore.Mvc;
using WebApiApplication.Controllers;
using Xunit;

namespace WebApiApplication.xUnit
{
    public class HomeControllerTest
    {
        HomeController controller { get; set; }

        public HomeControllerTest()
        {
            controller = new HomeController();
        }

        [Fact]
        public void UrlNotFound()
        {
            var result = controller.UrlNotFound();
            var redirectToActionResult = Assert.IsType<NotFoundObjectResult>(result);

            Assert.NotNull(redirectToActionResult.Value);
            Assert.Equal("URL not found", redirectToActionResult.Value);
            Assert.Equal(404, redirectToActionResult.StatusCode);
        }
    }
}
