namespace OutreachOperations.Api.Domain.Security
{
    public class RegistrationRequest
    {
        public string EmailAddress { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}