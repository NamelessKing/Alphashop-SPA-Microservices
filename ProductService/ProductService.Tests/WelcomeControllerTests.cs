using Microsoft.AspNetCore.Mvc;
using ProductService.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace ProductService.Tests
{
    public class WelcomeControllerTests
    {
        [Fact]
        public async Task WelcomeAsync_Returns_As_Expected()
        {
            // ARRANGE
            var systemUnderTest = new WelcomeController();
            IActionResult expected = new JsonResult("Welcome from WelcomeAsync() in WelcomeController.cs");

            // ACT
            var actual = await systemUnderTest.WelcomeAsync();

            // ASSERT
            Assert.Equal(expected.ToString(),actual.ToString());
        }

        [Fact]
        public async Task WelcomeAsync_With_name_Parameter_Returns_As_Expected()
        {
            // ARRANGE
            var systemUnderTest = new WelcomeController();
            string name = "name";
            IActionResult expected = await Task.FromResult(new JsonResult($"Welcome {name},from WelcomeAsync(string name) in WelcomeController.cs"));

            // ACT
            var actual = await systemUnderTest.WelcomeAsync(name);

            // ASSERT
            Assert.Equal(expected.ToString(), actual.ToString());
        }


    }
}
