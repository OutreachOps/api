using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OutreachOperations.Api.Domain.Security;

namespace OutreachOperations.Api.Controllers.Security
{
    [Route("login")]
    public class RegisterController : Controller
    {
        private readonly IConfiguration _configuration;

        RegisterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] RegistrationRequest request)
        {
            return BadRequest("Could not verify username and password");
        }


    }
}
