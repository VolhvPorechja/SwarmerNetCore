using Swarmer.AM.Contracts.Repositories;
using Swarmer.AM.DAL.Repositories;

namespace Swarmer.AM.DAL
{
    public class RepositoriesManager : RepositoriesManagerContract
    {
        public RepositoriesManager(string connectionString)
        {
            ConnectionString = connectionString;
            UsersRepository = new UsersRepository(this);
            TeamsRepository = new TeamsRepository(this);
        }

        internal string ConnectionString { get; }
        public UsersRepositoryContract UsersRepository { get; }
        public TeamsRepositoryContract TeamsRepository { get; }
    }
}