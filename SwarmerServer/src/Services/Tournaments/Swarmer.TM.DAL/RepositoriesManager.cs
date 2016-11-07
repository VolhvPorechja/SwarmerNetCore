using Swarmer.TM.Contracts.Repositories;

namespace Swarmer.TM.DAL
{
    public class RepositoriesManager : RepositoriesManagerContract
    {
        public string ConnectionString { get; }

        public RepositoriesManager(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public TournamentsRepositoryContract TournamentsRepository { get; }
        public PartiesRepositoryContract PartiesRepository { get; }
    }
}