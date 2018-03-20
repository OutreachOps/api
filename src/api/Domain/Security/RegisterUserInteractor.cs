using System;

namespace OutreachOperations.Api.Domain.Security
{
    public class RegisterUserInteractor
    {
        private readonly FindUserQuery _userQuery;
        private readonly FindUserQueryByEmail _emailQuery;

        public RegisterUserInteractor(FindUserQuery userQuery, FindUserQueryByEmail emailQuery)
        {
            _userQuery = userQuery;
            _emailQuery = emailQuery;
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

            if (!string.IsNullOrEmpty(result.ResultMessage))
                return result;

            if (_userQuery.Execute(request.Username) == null)
                result.ResultMessage = "Username exists, please choose another";

            if (_emailQuery.Execute(request.EmailAddress) == null)
                result.ResultMessage = "Email address exists";


            return result;
        }

        
    }

    public class RegistrationResult
    {
        public string ResultMessage { get; set; }
    }
}
