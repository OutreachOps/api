using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

        public class RegistrationRequest
        {
            public string EmailAddress { get; set; }

            public string Username { get; set; }
            public string Password { get; set; }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] RegistrationRequest request)
        {
            //check required fields on request

            //check whether email address exists.
            //check whether username exists.

            return BadRequest("Could not verify username and password");
        }


    }
}
