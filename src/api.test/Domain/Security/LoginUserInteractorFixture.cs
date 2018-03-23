using Moq;
using OutreachOperations.Api.Domain.Security;
using Xunit;

namespace OutreachOperations.Api.Test.Domain.Security
{
    public class LoginUserInteractorFixture
    {
        private readonly string _emailAddress = "email@email.com";

        [Fact]
        public void Execute_PasswordNotVerified_UserNotLoggedIn()
        {
            BCryptPasswordHash pwh = new BCryptPasswordHash();
            var hashedPassword = pwh.HashPassword("AReallyStringPassword");

            var emailQuery = new Mock<FindUserQueryByEmail>();
            emailQuery.Setup(x => x.Execute(_emailAddress)).Returns(new User
                { EmailAddress = _emailAddress,PasswordHash = hashedPassword });

            var interactor = new LoginUserInteractor(emailQuery.Object);

            var result = interactor.Execute(new LoginRequest{EmailAddress = _emailAddress,Password = "The incorrect password"});

            Assert.Equal("User Not Logged In",result.ResponseMessage);
        }

        [Fact]
        public void Execute_EmailAddressNotFound_UserNotLoggedIn()
        {
            var emailQuery = new Mock<FindUserQueryByEmail>();
            emailQuery.Setup(x => x.Execute(_emailAddress)).Returns((User)null);

            var interactor = new LoginUserInteractor(emailQuery.Object);

            var result = interactor.Execute(new LoginRequest { EmailAddress = _emailAddress, Password = "AReallyStringPassword" });

            Assert.Equal("User Not Logged In", result.ResponseMessage);
        }

        [Fact]
        public void Execute_EmailFoundAndPasswordVerified_UserLoggedIn()
        {
            BCryptPasswordHash pwh = new BCryptPasswordHash();
            var hashedPassword = pwh.HashPassword("AReallyStringPassword");

            var emailQuery = new Mock<FindUserQueryByEmail>();
            emailQuery.Setup(x => x.Execute(_emailAddress)).Returns(new User
                { EmailAddress = _emailAddress, PasswordHash = hashedPassword });


            var interactor = new LoginUserInteractor(emailQuery.Object);

            var result = interactor.Execute(new LoginRequest { EmailAddress = _emailAddress, Password = "AReallyStringPassword" });


            Assert.Equal("User Logged In", result.ResponseMessage);
        }
    }
}
