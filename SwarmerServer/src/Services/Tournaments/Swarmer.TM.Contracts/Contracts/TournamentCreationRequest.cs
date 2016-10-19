using Swarmer.TM.Contracts.Domain;

namespace Swarmer.TM.Contracts.Contracts
{
    /// <summary>
    /// Request on tournament creation.
    /// </summary>
    public class TournamentCreationRequest
    {
        /// <summary>
        /// Title of tournament.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Short name for tournament.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of tournament.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Type of creating tournament.
        /// </summary>
        public TournamentGrid Grid { get; set; }
    }
}