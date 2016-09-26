using Swarmer.AM.Contracts.Domain;
using Swarmer.AM.Contracts.Repositories;

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
            return new AuthResponse();
        }

        public LogoutResponse Logout(LogoutRequest data)
        {
            return new LogoutResponse();
        }
    }
}