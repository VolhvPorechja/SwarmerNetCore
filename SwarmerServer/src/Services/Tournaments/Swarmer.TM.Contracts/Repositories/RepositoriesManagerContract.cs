namespace Swarmer.TM.Contracts.Repositories
{
    /// <summary>
    /// Contract for repositories manager.
    /// </summary>
    public interface RepositoriesManagerContract
    {
        /// <summary>
        /// Tournaments repository.
        /// </summary>
        TournamentsRepositoryContract TournamentsRepository { get; }

        /// <summary>
        /// Parties repository.
        /// </summary>
        PartiesRepositoryContract PartiesRepository { get; }
    }
}