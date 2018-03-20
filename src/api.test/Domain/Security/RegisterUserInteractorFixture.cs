using OutreachOperations.Api.Domain;
using OutreachOperations.Api.Domain.Security;
using Xunit;

namespace OutreachOperations.Api.Test.Domain.Security
{
    public class RegisterUserInteractorFixture
    {
        [Fact]
        public void Execute_RegisterUser_RequiresPassword()
        {
            var interactor = RegisterUserInteractor();

            var result = interactor.Execute(
                GetRequest("email@email.com", "username", ""));

            Assert.Equal("Password is required to register",result.ResultMessage);
        }

        private static RegisterUserInteractor RegisterUserInteractor()
        {
            IRepository repository = null;
            var interactor = new RegisterUserInteractor(repository);
            return interactor;
        }

        [Fact]
        public void Execute_RegisterUser_RequiresEmailAddress()
        {
            var interactor = RegisterUserInteractor();

            var result = interactor.Execute(GetRequest("", "username", "password"));

            Assert.Equal("An email address is required to register", result.ResultMessage);
        }

        [Fact]
        public void Execute_RegisterUser_RequiresUserName()
        {
            var interactor = RegisterUserInteractor();

            var result = interactor.Execute(GetRequest("email@email.com", "", "password"));

            Assert.Equal("An username is required to register", result.ResultMessage);
        }

        private static RegistrationRequest GetRequest(string emailAddress, string username, string password)
        {
            return new RegistrationRequest
            {
                EmailAddress = emailAddress,
                Username = username,
                Password = password
            };
        }
    }
}
