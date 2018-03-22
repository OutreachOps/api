using OutreachOperations.Api.Domain.Security;
using Xunit;

namespace OutreachOperations.Api.Test.Domain.Security
{
    public class PasswordHashFixture
    {
        [Fact]
        public void CanHashAndVerifyPassword()
        {
            var passwordHashUtility = new BCryptPasswordHash();

            var hashed = passwordHashUtility.HashPassword("password");

            Assert.True(passwordHashUtility.VerifyPassword("password", hashed));
        }
    }
}
