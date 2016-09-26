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
            var user = mRepositoriesManager.UsersRepository.GetUserByLogin(request.Id);
            var authdata = mRepositoriesManager.UsersRepository.GetAuthenticationData(user.Id.Value, UsersApi.LoginTypes.LoginPassword);
            return authdata.Secret == request.Secret 
                ? AuthResponse.Success() 
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
                    IsSuccessful = false,
                    EmailExists = emailExists,
                    LoginExists = loginExists
                };

            return new PreSingUpResponse
            {
                IsSuccessful = true,
                Url = "/register.html"
            };
        }

    }
}