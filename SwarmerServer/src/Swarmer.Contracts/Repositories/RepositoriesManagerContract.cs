namespace Swarmer.AM.Contracts.Repositories
{
    /// <summary>
    /// Contract repositories manager.
    /// </summary>
    public interface RepositoriesManagerContract
    {
        /// <summary>
        /// Instance of users repository.
        /// </summary>
        UsersRepositoryContract UsersRepository { get; }

        /// <summary>
        /// Instance of teams repository.
        /// </summary>
        TeamsRepositoryContract TeamsRepository { get; }
    }
}