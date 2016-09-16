using System;
using System.Collections.Generic;
using Swarmer.AM.Contracts.Domain;
using Swarmer.AM.Contracts.Repositories;
using Swarmer.Common.Assetions;

namespace Swarmer.AM.Core
{
	public class UsersApi
	{
		private readonly RepositoriesManagerContract mRepositoriesManager;

		public UsersApi(RepositoriesManagerContract repositoriesManager)
		{
			mRepositoriesManager = repositoriesManager;
		}

		public UserInfo CreateUser(User newUser)
		{
			new Assertor(mess => new NotValidRequestException(mess))
				.Add(() => newUser != null, "Empty request not allowed", true)
				.Add(() => !string.IsNullOrEmpty(newUser.Login), "Login should be setted")
				.Add(() => !string.IsNullOrEmpty(newUser.FirstName), "Login should be setted")
				.Add(() => !string.IsNullOrEmpty(newUser.SecondName), "Login should be setted")
				.Assert();

			var result = new UserInfo();

			new Assertor(mess => new NotValidRequestException(mess))
				.Add(() => !mRepositoriesManager.UsersRepository.IsLoginExist(newUser.Login), $"Login {newUser.Login} already exists")
				.Add(() => !mRepositoriesManager.UsersRepository.IsEmailExists(newUser.Email), $"Email {newUser.Email} already registered")
				.Assert();

			mRepositoriesManager.UsersRepository.CreateUser(newUser);

			result.Id = newUser.Id;
			result.Created = newUser.Created;
			result.Updated = newUser.Updated;
			result.FirstName = newUser.FirstName;
			result.SecondName = newUser.SecondName;
			result.Login = newUser.Login;

			return result;
		}

		public List<UserInfo> ListUsers(int pageSize = 5, int pageNum = 0)
		{
			return mRepositoriesManager.UsersRepository.GetAll(pageSize, pageNum);
		}

		public User GetUser(Guid userId)
		{
			return mRepositoriesManager.UsersRepository.GetUserById(userId);
		}

		public User GetUser(string login)
		{
			return mRepositoriesManager.UsersRepository.GetUserByLogin(login);
		}

		public List<TeamMembership> GetUserTeamsMembership(Guid userId)
		{
			return mRepositoriesManager.UsersRepository.GetUserTeams(userId);
		}

		public void RequestUserTeamMembership(Guid userId, Guid teamId)
		{
			if (mRepositoriesManager.UsersRepository.IsMembershipOfTeam(userId, teamId))
				throw new NotValidRequestException($"User '{userId}' already member of team '{teamId}'");

			mRepositoriesManager.UsersRepository.RequestMembership(userId, teamId);
		}

		public UserInfo UpdateUserData(Guid userId, User updatedInfo)
		{
			if(!mRepositoriesManager.UsersRepository.IsUserExists(userId))
				throw new NotValidRequestException($"User {userId} doesn't exists.");

			updatedInfo.Id = userId;
			return mRepositoriesManager.UsersRepository.UpdateUser(updatedInfo);
		}

		public void RemoveUserTeammembership(Guid userId, Guid teamId)
		{
			new Assertor(mess => new NotValidRequestException(mess))
				.Add(() => mRepositoriesManager.UsersRepository.IsUserExists(userId), $"User with id='{userId}' doesn't exists")
				.Add(() => mRepositoriesManager.TeamsRepository.IsTeamExists(teamId), $"Team with id='{teamId}' doesn't exists")
				.Assert();

			if (!mRepositoriesManager.UsersRepository.IsMembershipOfTeam(userId, teamId))
				throw new NotValidRequestException($"User id='{userId}' doesn't have any membership in team id='{teamId}'");

			if (mRepositoriesManager.UsersRepository.GetUserTeamMembershipData(userId, teamId).Data.IsOwner == true)
				throw new NotValidRequestException($"Owner of team can't leave team.");

			mRepositoriesManager.UsersRepository.LeaveTeam(userId, teamId);
		}
	}
}
