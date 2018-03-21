using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var result = _interactor.Execute(request);

            if (string.IsNullOrEmpty(result.ResultMessage))
                return Ok();

            return BadRequest(result.ResultMessage);
        }


    }
}
