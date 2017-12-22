using System.Linq;
using WebApiApplication.Controllers;
using Xunit;

namespace WebApiApplication.xUnit
{
    public class ValuesControllerTest
    {
        ValuesController controller { get; set; }

        public ValuesControllerTest()
        {
            controller = new ValuesController();
        }

        [Fact]
        public void GetAllValues()
        {
            var values = GetValues();
            var result = controller.Get();

            Assert.Equal(values.Count(), result.Count());
        }

        [Fact]
        public void GetValuesById()
        {
            var values = GetValue();
            var result = controller.Get(0);

            Assert.Equal(values.Count(), result.Count());
        }

        private string[] GetValues()
        {
            return new string[] { "value1", "value2" };
        }

        private string GetValue()
        {
            return "value";
        }
    }
}
