using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Newtonsoft.Json.Linq;
using Swarmer.TM.Contracts.Domain;
using Swarmer.TM.Contracts.Repositories;

namespace Swarmer.TM.DAL.Repositories
{
    public class PartiesRepository : RepositoryBase, PartiesRepositoryContract
    {
        public PartiesRepository(RepositoriesManager manager) : base(manager)
        {
        }

        public IEnumerable<Party> GetTournamentParties(Guid tournamentId)
        {
            return
                mConnection.Query<Party>("SELECT * FROM Parties WHERE tournamentid = @tournamentid", new {tournamentId})
                    .AsEnumerable();
        }

        public Party GetPartyById(Guid partyId)
        {
            return mConnection.Query<Party>("SELECT * FROM Parties WHERE id = @partyid", new {partyId}).Single();
        }

        public void CreateTournamentParty(Party newParty)
        {
            DateTime now = DateTime.Now;;
            newParty.Id = Guid.NewGuid();
            newParty.Created = now;
            newParty.Updated = now;

            mConnection.Execute("INSERT INTO Parties(id,create,updated,tournamentid,creator,team,data) " +
                                "values(@id,@created,@updated,@tournamentid,@creator,@team,@data)", newParty);
        }

        public void UpdateTournamentPartyData(Party updatedParty)
        {
            updatedParty.Updated = DateTime.Now;
            mConnection.Execute("UPDATE Parties SET updated=@updated,name=@name,data=@data", updatedParty);
        }

        public void UpdateTournamentPartyStats(Guid partyId, JObject stats)
        {
            mConnection.Execute("UPDATE Parties SET stats=@stats WHERE id=@partyid", new {stats, partyId});
        }

        public void DeleteParty(Guid partyId)
        {
            mConnection.Execute("DELETE FROM Parties WHERE id=@partyid", new {partyId});
        }

        public void CreatePartyInvite(PartyInvite invite)
        {
            DateTime now = DateTime.Now;
            invite.Id = Guid.NewGuid();
            invite.Created = now;
            invite.Updated = now;

            mConnection.Execute("INSERT INTO PartiesInvites(id,created,updated,partyid,playerid)" +
                                "value(@id,@created,@updated,@partyid,@playerid)", invite);
        }

        public void UsePartyInvite(Guid inviteId)
        {
            mConnection.Execute("UPDATE PartiesInvites set used=true,updated=@updated where id=@inviteid",
                new {inviteId, updated = DateTime.Now});
        }

        public void RecallPartyInvite(Guid partyId)
        {
            mConnection.Execute("DELETE FROM PartiesInvites WHERE id=@partyid", new {partyId});
        }
    }
}