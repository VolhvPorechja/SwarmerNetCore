using System;
using System.Collections.Generic;
using Swarmer.AM.Contracts.Domain;
using Swarmer.AM.Contracts.Repositories;
using Swarmer.Common.Assetions;

namespace Swarmer.AM.Core
{
	public class TeamsApi
	{
		private readonly RepositoriesManagerContract mRepositoriesManager;

		public TeamsApi(RepositoriesManagerContract repositoriesManager)
		{
			mRepositoriesManager = repositoriesManager;
		}

		public Team GetTeam(Guid teamid)
		{
			return mRepositoriesManager.TeamsRepository.GetTeamById(teamid);
		}

		public List<TeamInfo> ListTeams(string filter = null, int page = 0, int pageSize = 5)
		{
			return mRepositoriesManager.TeamsRepository.GetAll(pageSize, page);
		}

		public TeamInfo CreateTeam(Team creatingTeam)
		{
			new Assertor(mess => new NotValidRequestException(mess))
				.Add(() => creatingTeam != null, "Empty request not allowed", true)
				.Add(() => !string.IsNullOrEmpty(creatingTeam.Name), "Team name should be specified")
				.Add(() => !string.IsNullOrEmpty(creatingTeam.FullName), "Full name should be specified")
				.Add(() => creatingTeam.Owner != null, "Owner should be specified")
				.Assert();

			if (!mRepositoriesManager.UsersRepository.IsUserExists(creatingTeam.Owner.Value))
				throw new NotValidRequestException($"User with id '{creatingTeam.Owner}' doesn't exists");
			if (mRepositoriesManager.TeamsRepository.IsTeamWithNameExists(creatingTeam.Name))
				throw new NotValidRequestException($"Team with name '{creatingTeam.Name}' already exists");

			mRepositoriesManager.TeamsRepository.CreateTeam(creatingTeam);
			mRepositoriesManager.TeamsRepository.GiveUserMembership(creatingTeam.Id.Value, creatingTeam.Owner.Value);

			return new TeamInfo
			{
				Id = creatingTeam.Id,
				Created = creatingTeam.Created,
				Updated = creatingTeam.Updated,
				Name = creatingTeam.Name
			};
		}

		public void ApprouveUserTeamMembershipRequest(Guid userId, Guid teamId)
		{
			new Assertor(mess => new NotValidRequestException(mess))
				.Add(() => mRepositoriesManager.UsersRepository.IsUserExists(userId), $"User with id='{userId}' doesn't exists")
				.Add(() => mRepositoriesManager.TeamsRepository.IsTeamExists(teamId), $"Team with id='{teamId}' doesn't exists")
				.Assert();
			
			mRepositoriesManager.TeamsRepository.GiveUserMembership(teamId, userId);
		}
	}
}