using System;

namespace OutreachOperations.Api.Domain.Security
{
    public class RegisterUserInteractor
    {
        public RegisterUserInteractor(IRepository repository)
        {
            
        }
        public RegistrationResult Execute(RegistrationRequest request)
        {
            var result = new RegistrationResult();

            //check whether password is complex enough
            //check whether email address is valid

            //check whether email has already been used
            //check whether username has already been used

            if (string.IsNullOrEmpty(request.Password))
                result.ResultMessage = "Password is required to register";

            if (string.IsNullOrEmpty(request.EmailAddress))
                result.ResultMessage = "An email address is required to register";

            if (string.IsNullOrEmpty(request.Username))
                result.ResultMessage = "An username is required to register";

            

            return result;
        }

        
    }

    public class RegistrationResult
    {
        public string ResultMessage { get; set; }
    }
}
