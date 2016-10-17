using Swarmer.AM.Contracts.Contracts;
using Swarmer.AM.Contracts.Domain;
using Swarmer.AM.Contracts.Repositories;
using Swarmer.Common.Assetions;

namespace Swarmer.AM.Core
{
    public class AuthenticationApi : ApiBase
    {
        public AuthenticationApi(RepositoriesManagerContract repositoriesManager)
            : base(repositoriesManager)
        {
        }

        public AuthResponse Authenticate(AuthRequest request)
        {
            new Assertor(mess => new NotValidRequestException(mess))
                .Add(() => !string.IsNullOrEmpty(request.Id), "Id of user can't be empty") // TODO change on codes for decision making on front-end part
                .Add(() => !string.IsNullOrEmpty(request.Secret), "Secret can't be empty")
                .Assert();

            var user = mRepositoriesManager.UsersRepository.GetUserByLogin(request.Id);
            if(user == null)
                return AuthResponse.Fail();

            var authdata = mRepositoriesManager.UsersRepository.GetAuthenticationData(user.Id.Value, UsersApi.LoginTypes.LoginPassword);
            return authdata != null && authdata.Secret == request.Secret
                ? AuthResponse.Success("/pages/index.html") 
                : AuthResponse.Fail();
        }

        public LogoutResponse Logout(LogoutRequest data)
        {
            return new LogoutResponse();
        }

        public PreSingUpResponse PreSingUp(PreSignUpRequest request)
        {
            new Assertor(mess => new NotValidRequestException(mess))
                .Add(() => !string.IsNullOrEmpty(request.Login), "Login can't be empty") // Check Login correctness
                .Add(() => !string.IsNullOrEmpty(request.Email), "Email can't be empty") // Check Email correctness
                .Assert();

            var loginExists = mRepositoriesManager.UsersRepository.IsLoginExist(request.Login);
            var emailExists = mRepositoriesManager.UsersRepository.IsEmailExists(request.Email);
            if (loginExists || emailExists)
                return new PreSingUpResponse
                {
                    IsSuccess = false,
                    EmailExists = emailExists,
                    LoginExists = loginExists
                };

            return new PreSingUpResponse
            {
                IsSuccess = true,
                Url = "/register.html"
            };
        }

    }
}