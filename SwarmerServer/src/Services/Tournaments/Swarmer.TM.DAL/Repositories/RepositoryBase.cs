using Npgsql;

namespace Swarmer.TM.DAL.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly RepositoriesManager mManager;
        protected readonly NpgsqlConnection mConnection;

        public RepositoryBase(RepositoriesManager manager)
        {
            mManager = manager;
            mConnection = new NpgsqlConnection(mManager.ConnectionString);
        }
    }
}