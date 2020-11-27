using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public async Task<string> WelcomeAsync()
        {
            return await Task.FromResult("Welcome from WelcomeAsync() in WelcomeController.cs");
        }

        [HttpGet("{name}")]
        public async Task<string> WelcomeAsync(string name)
        {
            return await Task.FromResult($"Welcome {name},from WelcomeAsync(string name) in WelcomeController.cs");
        }
    }
}
