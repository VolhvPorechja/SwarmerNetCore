using System;

namespace Swarmer.TM.Contracts.Contracts
{
    /// <summary>
    /// Request for tournament party creation.
    /// </summary>
    public class PartyCreationRequest
    {
        /// <summary>
        /// Name of party.
        /// </summary>
        public string PartyName { get; set; }

        /// <summary>
        /// Id of tournament for which party created.
        /// </summary>
        public Guid TournamentId { get; set; }

        /// <summary>
        /// If of team if party based on team.
        /// </summary>
        public Guid? TeamId { get; set; }
    }
}