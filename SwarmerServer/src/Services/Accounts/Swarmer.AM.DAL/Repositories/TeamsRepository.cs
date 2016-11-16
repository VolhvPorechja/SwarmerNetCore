using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dommel;
using Swarmer.AM.Contracts.Domain;
using Swarmer.AM.Contracts.Repositories;
using Swarmer.AM.DAL.Repositories.DTO;

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
						$"SELECT Id, Created, Updated, Name FROM Teams LIMIT {pageSize} OFFSET {pageNumber * pageSize}")
					.ToList();
		}

		public bool IsTeamExists(Guid id)
		{
			return mConnection.ExecuteScalar<bool>("SELECT exists(SELECT id FROM teams WHERE id = @id)", new { id });
		}

		public Team GetTeamById(Guid id)
		{
			var result = mConnection.Query<Team>("SELECT * FROM teams WHERE id = @id", new { id }).FirstOrDefault();
			if (result == null)
				return null;

			result.Members = GetTeamMembers(id);
			return result;
		}

		public bool IsTeamWithNameExists(string name)
		{
			return mConnection.ExecuteScalar<bool>("SELECT exists(SELECT id FROM Teams WHERE name = @name)", new { name });
		}

		public Team GetTeamByName(string name)
		{
			return mConnection.Query("SELECT * FROM Teams WHERE Name = @name", new { name }).FirstOrDefault();
		}

		public void CreateTeam(Team creatingTeam)
		{
			creatingTeam.Id = Guid.NewGuid();
			creatingTeam.Created = DateTime.Now;
			creatingTeam.Updated = creatingTeam.Created;

			mConnection.Execute(
				$"INSERT INTO Teams(Id, Created, Updated, Name, Owner, Fullname, Profile) VALUES(@Id, @Created, @Updated, @Name, @Owner, @Fullname, @Profile)",
				new
				{
					creatingTeam.Id,
					creatingTeam.Created,
					creatingTeam.Updated,
					creatingTeam.Name,
					creatingTeam.Owner,
					creatingTeam.FullName,
					Profile = new TeamProfileDTO(creatingTeam.Profile)
				});
		}

		public void UpdateTeam(Team updatedInfo)
		{
			mConnection.Update(updatedInfo);
		}

		public void BlockTeam(Guid teamId, string reason)
		{
			throw new System.NotImplementedException();
		}

		public List<TeamMembership> GetTeamMembers(Guid teamId)
		{
			return
				mConnection.Query<TeamMembership>("SELECT * FROM teamsmembership WHERE teamid = @teamid", new {teamId}).ToList();
		}

		public void GiveUserMembership(Guid teamId, Guid userId, bool? isOwner = false)
		{
			var membership = mConnection.Query<TeamMembership>(
				"SELECT id, created, updated, teamid, userid, data FROM teamsmembership WHERE teamid = @teamId AND userid = @userId",
				new { teamId, userId }).FirstOrDefault();

			var now = DateTime.Now;
			if (membership == null)
			{
				mConnection.Execute("INSERT INTO teamsmembership(id, created, updated, teamid, userid, data)" +
									"values (@id, @created, @updated, @teamid, @userid, @data)", new
									{
										Id = Guid.NewGuid(),
										Created = now,
										Updated = now,
										TeamId = teamId,
										UserId = userId,
										Data = new TeamMembershipDataDTO
										{
											Approuved = true,
											IsActive = true,
											StartDate = now,
											IsOwner = isOwner
										}
									});
			}
			else
			{
				membership.Updated = now;
				mConnection.Execute("UPDATE teamsmembership set updated = @updated, data = @data WHERE id = @id", new
				{
					Updated = now,
					Data = new TeamMembershipDataDTO
					{
						IsActive = true,
						Approuved = true,
						StartDate = now
					},
					membership.Id
				});
			}
		}

		public void StopUserMembership(Guid teamId, Guid userId)
		{
			throw new System.NotImplementedException();
		}
	}
}