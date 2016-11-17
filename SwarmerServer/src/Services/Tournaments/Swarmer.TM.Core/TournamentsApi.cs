using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Swarmer.Common;
using Swarmer.Common.Assetions;
using Swarmer.TM.Contracts.Contracts;
using Swarmer.TM.Contracts.Domain;
using Swarmer.TM.Contracts.Providers;
using Swarmer.TM.Contracts.Repositories;

namespace Swarmer.TM.Core
{
	public class TournamentsApi
	{
		private readonly RepositoriesManagerContract mReposManager;
		private readonly UserDataProviderContract mUserDataProvider;

		public TournamentsApi(RepositoriesManagerContract reposManager,
			UserDataProviderContract userDataProvider)
		{
			mUserDataProvider = userDataProvider;
			mReposManager = reposManager;
		}

		#region Tournaments

		public Tournament CreateTournament(TournamentCreationRequest request)
		{
			var newTournament = new Tournament
			{
				Begin = request.Begin,
				Name = request.Name,
				Description = request.Description,
				Data = new TournamentData
				{
					Grid = request.Grid
				},
				Title = request.Title,
				IsOpen = request.IsOpen,
				State = 0,
				Owner = mUserDataProvider.GetUserData<Guid>("id")
			};

			mReposManager.TournamentsRepository.CreateTournament(newTournament);

			return newTournament;
		}

		public Tournament GetTournament(Guid tournamentId)
		{
			return mReposManager.TournamentsRepository.GetById(tournamentId);
		}

		public Tournament UpdateTournament(Guid tournamendId, TournamentUpdateRequest request)
		{
			var tournament = mReposManager.TournamentsRepository.GetById(tournamendId);

			if (!string.IsNullOrEmpty(request.Title))
				tournament.Title = request.Title;

			if (!string.IsNullOrEmpty(request.Name))
				tournament.Name = request.Name;

			if (!string.IsNullOrEmpty(request.Description))
				tournament.Description = request.Description;

			if (request.Begin.HasValue)
				tournament.Begin = request.Begin.Value;

			if (request.Grid != null)
				tournament.Data.Grid = request.Grid;

			mReposManager.TournamentsRepository.UpdateTournament(tournament);

			return tournament;
		}

		public void DeleteTournament(Guid tournamentId)
		{
			mReposManager.TournamentsRepository.DeleteTournament(tournamentId);
		}

	    public void UpdateTournamentStats(Guid tournamentId, JObject stats)
	    {
            mReposManager.TournamentsRepository.UpdateTournamentStats(tournamentId, stats);
	    }

		#endregion

		#region Invites

		public IEnumerable<TournamentInvite> GetTournamentInvites(Guid tournamentId)
		{
			return mReposManager.TournamentsRepository.GetTorunamentInvites(tournamentId);
		}

		public IEnumerable<TournamentInvite> GetUserInvites(Guid userId)
		{
			return mReposManager.TournamentsRepository.GetUserInvites(userId);
		}

		public IEnumerable<TournamentInvite> GetTeamInvites(Guid teamId)
		{
			return mReposManager.TournamentsRepository.GetTeamInvites(teamId);
		}

		public TournamentPlayer JoinTournament(JoinTournamentRequest request)
		{
            new RequestValidator<JoinTournamentRequest>(request)
                .Assert();

		    var tournament = mReposManager.TournamentsRepository.GetById(request.TournamentId);
		    var invites = tournament.IsOpen
		        ? null
		        : mReposManager.TournamentsRepository.FindTournamentInvite(request.TournamentId, request.UserId,
		            request.TeamId ?? Guid.Empty).ToList();

		    if (!tournament.IsOpen && !invites.Any())
		        throw new BusinsessLogicException("NOTINVITED", "Not invited on closed tournament");

            foreach (var playerInvite in invites.Where(el => el.Player.HasValue))
            {
                if (playerInvite.Used)
                    throw new BusinsessLogicException("ALREADYPARTICIPATED", "Already in tournament");
                mReposManager.TournamentsRepository.UseTournamentInvite(playerInvite.Id.Value);
            }

            var newPlayer = new TournamentPlayer
		    {
		        PlayerId = request.UserId,
		        TeamId = request.TeamId,
		        TournamentId = request.TournamentId
		    };
            mReposManager.TournamentsRepository.AddTournamentPlayer(newPlayer);

            return newPlayer;
        }

	    public void InvitePlayerOrTeam(TournamentInvite invite)
	    {
	        mReposManager.TournamentsRepository.CreateTournamentInvite(invite);
	    }

        #endregion

	    #region Parties

	    public IEnumerable<Party> GetTournamentParties(Guid tournamentId)
	    {
	        return mReposManager.TournamentsRepository.GetTorunamentParties(tournamentId);
	    }

        #endregion

	    #region Games

	    public TournamentGrid GetTournamentGrid(Guid tournamentId)
	    {
	        var tournament = mReposManager.TournamentsRepository.GetById(tournamentId);
	        return tournament.Data.Grid;
	    }

	    public void UpdateTournamentGrid(Guid tournamentId, TournamentGrid updatedGrid)
	    {
	        var tournament = mReposManager.TournamentsRepository.GetById(tournamentId);
	        tournament.Data.Grid = updatedGrid;
	        mReposManager.TournamentsRepository.UpdateTournament(tournament);
	    }

	    #endregion
    }
}
