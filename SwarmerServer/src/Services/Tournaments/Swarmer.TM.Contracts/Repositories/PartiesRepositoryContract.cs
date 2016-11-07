using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Swarmer.TM.Contracts.Domain;

namespace Swarmer.TM.Contracts.Repositories
{
    /// <summary>
    /// Contract for repository of parties.
    /// </summary>
    public interface PartiesRepositoryContract
    {
        #region Parties

        IEnumerable<Party> GetTournamentParties(Guid tournamentId);
        Party GetPartyById(Guid partyId);
        void CreateTournamentParty(Party newParty);
        void UpdateTournamentPartyData(Party updatedParty);
        void UpdateTournamentPartyStats(Guid partyId, JObject stats);
        void DeleteParty(Guid partyId);

        #endregion

        #region Invites

        void CreatePartyInvite(PartyInvite invite);
        void UsePartyInvite(Guid inviteId);
        void RecallPartyInvite(Guid partyId);

        #endregion
    }
}