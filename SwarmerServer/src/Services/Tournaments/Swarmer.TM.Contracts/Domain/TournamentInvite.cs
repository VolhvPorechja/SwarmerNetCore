using System;
using Swarmer.Common.Models;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Invite on tournament.
    /// </summary>
    public class TournamentInvite: SysObject
    {
        /// <summary>
        /// Id of player that invited.
        /// </summary>
        public Guid? Player { get; set; }

        /// <summary>
        /// Id of team that invited.
        /// </summary>
        public Guid? Team { get; set; }

        /// <summary>
        /// Id of user that invited on tournament.
        /// </summary>
        public Guid Inviter { get; set; }

        /// <summary>
        /// Id of tounament on which invited created.
        /// </summary>
        public Guid Tournament { get; set; }

        /// <summary>
        /// Is invite used.
        /// </summary>
        public bool Used { get; set; } = false;
    }
}