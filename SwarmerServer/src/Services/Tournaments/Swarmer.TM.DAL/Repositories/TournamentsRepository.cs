using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Newtonsoft.Json.Linq;
using Swarmer.TM.Contracts.Domain;
using Swarmer.TM.Contracts.Repositories;

namespace Swarmer.TM.DAL.Repositories
{
    public class TournamentsRepository : RepositoryBase, TournamentsRepositoryContract
    {
        public TournamentsRepository(RepositoriesManager manager) : base(manager)
        {
        }

        public IEnumerable<Tournament> GetTournaments(int pageSize, int pageNum)
        {
            return mConnection.Query<Tournament>($"SELECT * FROM Tournaments LIMIT {pageSize} OFFSET {pageSize * pageNum}");
        }

        public Tournament GetById(Guid id)
        {
            return mConnection.Query<Tournament>("SELECT * FROM Tournaments WHERE id=@id", new { id }).Single();
        }

        public Tournament GetByName(string name)
        {
            return mConnection.Query<Tournament>("SELECT * FROM Tournaments WHERE name=@name", new { name }).Single();
        }

        public void CreateTournament(Tournament newTournament)
        {
            DateTime now = DateTime.Now;
            newTournament.Id = Guid.NewGuid();
            newTournament.Created = now;
            newTournament.Updated = now;

            mConnection.Execute(
                "INSERT INTO Torunaments(id,created,updated,begin,owner,state,title,name,description,data,isopen)" +
                "values(@id,@created,@updated,@begin,@owner,@state,@title,@name,@description,@data,@isopen)", newTournament);
        }

        public void UpdateTournament(Tournament updatedTournament)
        {
            updatedTournament.Updated = DateTime.Now;

            mConnection.Execute("UPDATE Tournaments SET title=@title,name=@name,begin=@begin,description=@description,isopen=@isopen,data=@data,state=@state" +
                                "where id=@id", updatedTournament);
        }

        public void DeleteTournament(Guid id)
        {
            mConnection.Execute("DELETE FROM Tournaments WHERE id=@id", new { id });
        }

        public IEnumerable<Tournament> GetTournamentsByOwner(Guid userId)
        {
            return mConnection.Query<Tournament>("SELECT * FROM Tournaments WHERE owner=@userid", new { userId });
        }

        public void UpdateTournamentStats(Guid tournamentId, JObject stats)
        {
            mConnection.Execute("UPDATE Tournament SET state=@state WHERE id=@tournamentid", new { tournamentId });
        }

        public void CreateTournamentInvite(TournamentInvite invite)
        {
            DateTime now = DateTime.Now;
            invite.Id = Guid.NewGuid();
            invite.Created = now;
            invite.Updated = now;

            mConnection.Execute("INSERT INTO TournamentsInvites(id,created,updated,tournamentid,playerid.teamid,inviter)" +
                                "values(@id,@created,@updated,@tournamentid,@playerid.@teamid,@inviter)", invite);
        }

        public void UseTournamentInvite(Guid inviteId)
        {
            mConnection.Execute("UPDATE TournamentsInvites SET used=true,updated=@updated WHERE id=@inviteid",
                new {inviteId, updated = DateTime.Now});
        }

        public void RecallTournamentInvite(Guid inviteId)
        {
            mConnection.Execute("DELETE FROM TournamentsInvites WHERE id=@inviteid", new {inviteId});
        }

        public IEnumerable<TournamentInvite> GetUserInvites(Guid userId)
        {
            return mConnection.Query<TournamentInvite>("SELECT * FROM TournamentsInvites WHERE playerid=@userid");
        }

        public IEnumerable<TournamentInvite> GetTeamInvites(Guid teamId)
        {
            return mConnection.Query<TournamentInvite>("SELECT * FROM Tournaments WHERE teamid=@teamid", new {teamId});
        }
    }
}