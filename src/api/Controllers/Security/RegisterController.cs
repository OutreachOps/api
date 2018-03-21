using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OutreachOperations.Api.Domain.Security;

namespace OutreachOperations.Api.Controllers.Security
{
    [Route("register")]
    public class RegisterController : Controller
    {
        private readonly RegisterUserInteractor _interactor;

        public RegisterController(RegisterUserInteractor interactor)
        {
            _interactor = interactor;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] RegistrationRequest request)
        {
            _interactor.Execute(request);

            return BadRequest("Could not verify username and password");
        }


    }
}
