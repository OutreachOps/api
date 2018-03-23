using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OutreachOperations.Api.Domain.Security;

namespace OutreachOperations.Api.Controllers.Security
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly LoginUserInteractor _interactor;

        public LoginController(IConfiguration configuration,LoginUserInteractor interactor)
        {
            _configuration = configuration;
            _interactor = interactor;
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = _interactor.Execute(new Domain.Security.LoginRequest
                {EmailAddress = request.Username, Password = request.Password});

            if (result.ResponseMessage == "User Logged In")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    _configuration["Domain"],
                    _configuration["Domain"],
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Could not verify username and password");
        }
    }
}
