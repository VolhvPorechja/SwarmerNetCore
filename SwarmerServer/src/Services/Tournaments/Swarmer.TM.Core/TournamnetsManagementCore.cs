using Swarmer.TM.Contracts.Providers;
using Swarmer.TM.Contracts.Repositories;

namespace Swarmer.TM.Core
{
    public class TournamentsManagementCore
    {
        public TournamentsManagementCore(RepositoriesManagerContract reposManager,
            UserDataProviderContract userDataProvider)
        {
            TournamentsApi = new TournamentsApi(reposManager, userDataProvider);
            PartiesApi = new PartiesApi(reposManager, userDataProvider);
        }

        public TournamentsApi TournamentsApi { get; }

        public PartiesApi PartiesApi { get; }
    }
}
