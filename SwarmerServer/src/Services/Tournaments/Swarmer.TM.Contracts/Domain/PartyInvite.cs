using System;
using Swarmer.Common.Models;

namespace Swarmer.TM.Contracts.Domain
{
    /// <summary>
    /// Invite in party.
    /// </summary>
    public class PartyInvite: SysObject
    {
        /// <summary>
        /// Id of party in which player invited.
        /// </summary>
        public Guid PartyId { get; set; }

        /// <summary>
        /// Id of player that invited.
        /// </summary>
        public Guid PayerId { get; set; }

        /// <summary>
        /// Is invite used.
        /// </summary>
        public bool Used { get; set; }
    }
}