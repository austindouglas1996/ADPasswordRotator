using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADPasswordRotator.Backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize]
    [Route("api/[controller]")]
    public class AuthProtectedController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is a protected API endpoint.");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Posted data successfully.");
        }
    }
}
