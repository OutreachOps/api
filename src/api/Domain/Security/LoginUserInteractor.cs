namespace OutreachOperations.Api.Domain.Security
{
    public class LoginUserInteractor
    {
        private readonly FindUserQueryByEmail _emailQueryObject;

        public LoginUserInteractor(FindUserQueryByEmail emailQueryObject, PasswordHash pwh)
        {
            _emailQueryObject = emailQueryObject;
        }

        public LoginUserInteractor()
        {

        }

        public virtual LoginResponse Execute(LoginRequest request)
        {
            var user =  _emailQueryObject.Execute(request.EmailAddress);

            if (user == null)
                 return new LoginResponse{ResponseMessage = "User Not Logged In"};
                    
            BCryptPasswordHash pwHash = new BCryptPasswordHash();
            var result = pwHash.VerifyPassword(request.Password, user.PasswordHash);

            if (result)
                return new LoginResponse { ResponseMessage = "User Logged In" };

            //TODO:Log login failures
            //TODO:Log login success
            //TODO:Generate and return JWT

            return new LoginResponse{ResponseMessage = "User Not Logged In" };
        }
    }

    public class LoginRequest
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string ResponseMessage { get; set; }
    }
}
