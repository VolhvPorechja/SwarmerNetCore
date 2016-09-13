using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dommel;
using Swarmer.AM.Contracts.Domain;
using Swarmer.AM.Contracts.Repositories;

namespace Swarmer.AM.DAL.Repositories
{
    public class TeamsRepository : RepositoryBase, TeamsRepositoryContract
    {
        public TeamsRepository(RepositoriesManager manager) : base(manager)
        {
        }

        public List<TeamInfo> GetAll(int pageSize, int pageNumber)
        {
            return
                mConnection.Query<TeamInfo>(
                        $"SELECT Id, Created, Updated, Name FROM Teams LIMIT {pageSize} OFFSET {(pageNumber - 1) * pageSize}")
                    .ToList();
        }

        public Team GetTeamById(int id)
        {
            return mConnection.Get<Team>(id);
        }

        public Team GetTeamByName(string name)
        {
            return mConnection.Query("SELECT * FROM Teams WHERE Name = @name", new { name }).FirstOrDefault();
        }

        public void CreateTeam(Team creatingTeam)
        {
            creatingTeam.Id = (int) mConnection.Insert(creatingTeam);
        }

        public void UpdateTeam(Team updatedInfo)
        {
            mConnection.Update(updatedInfo);
        }

        public void BlockTeam(int teamId, string reason)
        {
            throw new System.NotImplementedException();
        }

        public List<TeamMembership> GetTeamMembers()
        {
            return mConnection.GetAll<TeamMembership>().ToList();
        }

        public void GiveUserMembership(int teamId, int userId)
        {
            throw new System.NotImplementedException();
        }

        public void StopUserMembership(int teamId, int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}