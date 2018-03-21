using Microsoft.AspNetCore.Mvc;
using Moq;
using OutreachOperations.Api.Controllers.Security;
using OutreachOperations.Api.Domain.Security;
using Xunit;

namespace OutreachOperations.Api.Test.Controllers
{
    public class RegisterControllerFixture
    {
        [Fact]
        public void Register_ReturnsOk_UserRegistered()
        {
            var request = new RegistrationRequest();
            var interactor = new Mock<RegisterUserInteractor>();
            interactor.Setup(x => x.Execute(request)).Returns(new RegistrationResult());

            RegisterController controller = new RegisterController(interactor.Object);

            var result = controller.Register(request);

            var resultAsStatus = result as OkResult;

            Assert.NotNull(resultAsStatus);
            Assert.Equal(200, resultAsStatus.StatusCode);
            interactor.Verify();
        }

        [Fact]
        public void Register_ReturnsBadRequest_UserNotRegistered()
        {
            var request = new RegistrationRequest();
            var interactor = new Mock<RegisterUserInteractor>();
            interactor.Setup(x => x.Execute(request)).Returns(new RegistrationResult {ResultMessage = "ErrorMessage"});

            RegisterController controller = new RegisterController(interactor.Object);

            var result = controller.Register(request);

            var resultAsStatus = result as BadRequestObjectResult;

            Assert.NotNull(resultAsStatus);
            Assert.Equal(400, resultAsStatus.StatusCode);
            interactor.Verify();
        }

    }
}
