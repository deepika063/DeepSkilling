using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthenticationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        [Authorize(Roles = "Admin")]

        [HttpGet("dashboard")]

        public IActionResult Dashboard()
        {
            return Ok("Welcome to the admin dashboard.");
        }
    }
}
