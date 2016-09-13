using Swarmer.AM.Contracts.Repositories;

namespace Swarmer.AM.Core
{
    public class UsersApi
    {
        private RepositoriesManagerContract mRepositoriesManager;

        public UsersApi(RepositoriesManagerContract repositoriesManager)
        {
            mRepositoriesManager = repositoriesManager;
        }
    }
}
