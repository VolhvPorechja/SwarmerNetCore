using Swarmer.AM.Contracts.Repositories;

namespace Swarmer.AM.Core
{
    public abstract class ApiBase
    {
        protected readonly RepositoriesManagerContract mRepositoriesManager;

        protected ApiBase(RepositoriesManagerContract repositoriesManager)
        {
            mRepositoriesManager = repositoriesManager;
        }
    }
}