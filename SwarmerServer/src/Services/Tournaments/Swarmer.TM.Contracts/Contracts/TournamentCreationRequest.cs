using System;
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
        /// Begin of tournament.
        /// </summary>
        public DateTime Begin { get; set; }

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

        /// <summary>
        /// Is tournament open for joining.
        /// </summary>
        public bool IsOpen { get; set; }
    }
}