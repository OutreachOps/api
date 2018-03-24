namespace OutreachOperations.Api.Domain.Security
{
    public class RegisterUserInteractor
    {
        private readonly FindUserQuery _userQuery;
        private readonly FindUserQueryByEmail _emailQuery;
        private readonly IRepository _repository;
        private readonly PasswordHash _passwordHash;

        public RegisterUserInteractor()
        {

        }

        public RegisterUserInteractor(FindUserQuery userQuery, FindUserQueryByEmail emailQuery,IRepository repository,PasswordHash passwordHash)
        {
            _userQuery = userQuery;
            _emailQuery = emailQuery;
            _repository = repository;
            _passwordHash = passwordHash;
        }
        public virtual RegistrationResult Execute(RegistrationRequest request)
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

            //TODO:Change query objects to Query Processor
            if (_userQuery.Execute(request.Username) != null)
                result.ResultMessage = "Username exists, please choose another";

            if (_emailQuery.Execute(request.EmailAddress) != null)
                result.ResultMessage = "Email address exists";

            if (!string.IsNullOrEmpty(result.ResultMessage))
                return result;

            var passwordHash = _passwordHash.HashPassword(request.Password);

            _repository.Insert(new User
            {
                EmailAddress = request.EmailAddress,
                PasswordHash = passwordHash,
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
