using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YarpApiGateway.Controllers
{
    [Controller]
    public class TestController : Controller
    {
        [HttpGet("test")]
        [Authorize]
        public IActionResult Index()
        {
            return Ok("123");
        }
    }
}
