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
	public class UsersRepository : RepositoryBase, UsersRepositoryContract
	{
		public UsersRepository(RepositoriesManager manager) : base(manager)
		{
		}

		public List<UserInfo> GetAll(int pageSize, int pageNumber)
		{
			return
				mConnection.Query<UserInfo>(
						$"SELECT Id, Created, Updated, FirstName, SecondName, Login FROM Users LIMIT {pageSize} OFFSET {pageSize * pageNumber}")
					.ToList();
		}

		public bool IsUserExists(Guid userId)
		{
			return mConnection.ExecuteScalar<int>("SELECT count(id) FROM users WHERE Id = @userId", new {userId}) != 0;
		}

		public bool IsLoginExists(string login)
		{
			return mConnection.ExecuteScalar<bool>("SELECT exists(SELECT * FROM users WHERE login = @login)", new {login});
		}

		public bool IsEmailExists(string email)
		{
			return mConnection.ExecuteScalar<bool>("SELECT exists(SELECT * FROM users WHERE email = @email)", new {email});
		}

		public User GetUserById(Guid id)
		{
			return mConnection.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
		}

		public User GetUserByLogin(string login)
		{
			return mConnection.Query<User>("SELECT * FROM Users WHERE Login = @login", new { login }).FirstOrDefault();
		}

		public UserInfo UpdateUser(User updatedInfo)
		{
			updatedInfo.Updated = DateTime.Now;

			mConnection.Execute(
				$"UPDATE Users SET Updated = @Updated, FirstName = @FirstName, SecondName = @SecondName, Gender = @Gender, Role = @Role, SteamId = @SteamId, BirthDate = @BirthDate, " +
				$"Address = @Address, TimeZone = @TimeZone, Country = @Country, Profile = @Profile WHERE id = @id",
				new
				{
					updatedInfo.Id,
					updatedInfo.Updated,
					updatedInfo.FirstName,
					updatedInfo.SecondName,
					updatedInfo.Gender,
					updatedInfo.Role,
					updatedInfo.SteamId,
					updatedInfo.BirthDate,
					updatedInfo.Address,
					updatedInfo.TimeZone,
					updatedInfo.Country,
					Profile = new UserProfileDTO(updatedInfo.Profile)
				});

			return
				mConnection.Query<UserInfo>("SELECT id, created, updated, firstname, secondname, login FROM users WHERE id = @id", updatedInfo)
					.FirstOrDefault();
		}

		public void CreateUser(User creatingUser)
		{
			creatingUser.Id = Guid.NewGuid();
			creatingUser.Created = DateTime.Now;
			creatingUser.Updated = creatingUser.Created;
			creatingUser.Profile = creatingUser.Profile ?? new UserProfile();

			mConnection.Execute(
				$"INSERT INTO Users(Id, Created, Updated, FirstName, SecondName, Login, Email, Gender, Role, SteamId, BirthDate, Address, Timezone, Country, Profile, PhoneNumber)" +
				$"values(@Id, @Created, @Updated, @FirstName, @SecondName, @Login, @Email, @Gender, @Role, @SteamId, @BirthDate, @Address, @Timezone, @Country, @Profile, @PhoneNumber)",
				new
				{
					creatingUser.Id,
					creatingUser.Created,
					creatingUser.Updated,
					creatingUser.FirstName,
					creatingUser.SecondName,
					creatingUser.Login,
					creatingUser.Email,
					creatingUser.Gender,
					creatingUser.Role,
					creatingUser.SteamId,
					creatingUser.BirthDate,
					creatingUser.Address,
					creatingUser.TimeZone,
					creatingUser.Country,
					Profile = new UserProfileDTO(creatingUser.Profile),
					creatingUser.PhoneNumber
				});
		}

		public void BlockUser(string login, string reason)
		{
			throw new NotImplementedException();
		}

		public bool IsLoginExist(string login)
		{
			return mConnection.ExecuteScalar<int>($"SELECT count(Id) FROM Users WHERE Login = @login", new { login }) != 0;
		}

		public List<TeamMembership> GetUserTeams(Guid id)
		{
			return
				mConnection.Query<TeamMembership>("SELECT * FROM TeamsMembership WHERE UserId = @id", new { id }).ToList();
		}

		public TeamMembership GetUserTeamMembershipData(Guid userId, Guid teamId)
		{
			return
				mConnection.Query<TeamMembership>("SELECT * FROM TeamsMembership WHERE userid = @userid AND teamid = @teamid",
					new {userId, teamId}).FirstOrDefault();
		}

		public bool IsMembershipOfTeam(Guid userId, Guid teamId)
		{
			return
				mConnection.ExecuteScalar<bool>(
					"SELECT exists(SELECT * FROM teamsmembership WHERE userid = @userid AND teamid = @teamid)", new {userId, teamId});
		}
		
		public void RequestMembership(Guid userId, Guid teamId)
		{
			var now = DateTime.Now;
			mConnection.Execute($"INSERT INTO teamsmembership(id, created, updated, teamid, userid, data)" +
								$"values(@id, @created, @updated, @teamid, @userid, @data)",
				new
				{
					Id = Guid.NewGuid(),
					Created = now,
					Updated = now,
					teamId,
					userId,
					data = new TeamMembershipDataDTO(Approuved: false, IsActive: false)
				});
		}

		public void LeaveTeam(Guid userId, Guid teamId)
		{
			mConnection.Execute("DELETE FROM teamsmembership WHERE userid = @userid AND teamid = @teamid", new {userId, teamId});
		}
	}
}