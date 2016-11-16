using Swarmer.TM.Contracts.Providers;
using Swarmer.TM.Contracts.Repositories;

namespace Swarmer.TM.Core
{
    public class PartiesApi
    {
        private RepositoriesManagerContract mReposManager;
        private UserDataProviderContract mUserDataProvider;

        public PartiesApi(RepositoriesManagerContract reposManager,
            UserDataProviderContract userDataProvider)
        {
            mUserDataProvider = userDataProvider;
            mReposManager = reposManager;
        }
    }
}