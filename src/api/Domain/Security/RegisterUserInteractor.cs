namespace OutreachOperations.Api.Domain.Security
{
    public class RegisterUserInteractor
    {
        private readonly FindUserQuery _userQuery;
        private readonly FindUserQueryByEmail _emailQuery;
        private readonly IRepository _repository;

        public RegisterUserInteractor(FindUserQuery userQuery, FindUserQueryByEmail emailQuery,IRepository repository)
        {
            _userQuery = userQuery;
            _emailQuery = emailQuery;
            _repository = repository;
        }
        public RegistrationResult Execute(RegistrationRequest request)
        {
            var result = new RegistrationResult();

            //check whether password is complex enough
            //check whether email address is valid

            if (string.IsNullOrEmpty(request.Password))
                result.ResultMessage = "Password is required to register";

            if (string.IsNullOrEmpty(request.EmailAddress))
                result.ResultMessage = "An email address is required to register";

            if (string.IsNullOrEmpty(request.Username))
                result.ResultMessage = "An username is required to register";

            if (!string.IsNullOrEmpty(result.ResultMessage))
                return result;

            if (_userQuery.Execute(request.Username) != null)
                result.ResultMessage = "Username exists, please choose another";

            if (_emailQuery.Execute(request.EmailAddress) != null)
                result.ResultMessage = "Email address exists";

            if (!string.IsNullOrEmpty(result.ResultMessage))
                return result;


            _repository.Insert(new User()
            {
                EmailAddress = request.EmailAddress,
                PasswordHash = request.Password,
                UserName = request.Username
            });

            return result;
        }

        
    }

    public class RegistrationResult
    {
        public string ResultMessage { get; set; }
    }
}
