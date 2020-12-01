using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> WelcomeAsync()
        {
            return await Task.FromResult(new JsonResult("Welcome from WelcomeAsync() in WelcomeController.cs"));
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> WelcomeAsync(string name)
        {
            try
            {
                if (name != "tan")
                {
                    throw new Exception("Error: invalid user");
                }
                else
                {
                    return await Task.FromResult(new JsonResult($"Welcome {name},from WelcomeAsync(string name) in WelcomeController.cs"));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message));
            }
            
        }
    }
}
