using Microsoft.AspNetCore.Mvc;
using Moq;
using OutreachOperations.Api.Controllers.Security;
using OutreachOperations.Api.Domain.Security;
using Xunit;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OutreachOperations.Api.Test.Controllers
{
    public class LoginControllerFixture
    {
        [Fact]
        public void Login_WithKnownUser_LogsIn()
        {
            var configuration = new Mock<IConfiguration>();
            configuration.SetupGet(p => p["JWTKey"]).Returns("foofoofoofoofoofoofoo");
            configuration.SetupGet(p => p["Domain"]).Returns("bar.com");
            var interactor = new Mock<LoginUserInteractor>();
            interactor.Setup(x => x.Execute(It.IsAny<LoginRequest>()))
                .Returns(new LoginResponse {ResponseMessage = "User Logged In"});

            var controller = new LoginController(configuration.Object,interactor.Object);

            var result = controller.Login(new LoginController.LoginRequest(){Username = "email@email.com"});

            var resultAsStatus = result as OkObjectResult;

            Assert.NotNull(resultAsStatus);
            Assert.Equal(200, resultAsStatus.StatusCode);
            interactor.Verify();
        }
    }
}
