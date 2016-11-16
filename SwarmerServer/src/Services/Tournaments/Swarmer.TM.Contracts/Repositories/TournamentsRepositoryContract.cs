using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Swarmer.TM.Contracts.Domain;

namespace Swarmer.TM.Contracts.Repositories
{
    /// <summary>
    /// Contract for
    /// </summary>
    public interface TournamentsRepositoryContract
    {
        #region Tournaments

        /// <summary>
        /// Get all tournaments.
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        IEnumerable<Tournament> GetAll(int pageSize, int pageNum);

        /// <summary>
        /// Get tournament by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Tournament GetById(Guid id);
		 
        /// <summary>
        /// Get tournament by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Tournament GetByName(string name);

        /// <summary>
        /// Create new tournament.
        /// </summary>
        /// <param name="newTournament"></param>
        void CreateTournament(Tournament newTournament);

        /// <summary>
        /// Update tournament data.
        /// </summary>
        /// <param name="updatedTournament"></param>
        void UpdateTournament(Tournament updatedTournament);

        /// <summary>
        /// Delete tournament by id.
        /// </summary>
        /// <param name="id"></param>
        void DeleteTournament(Guid id);

        /// <summary>
        /// Get tournament by owner.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<Tournament> GetTournamentsByOwner(Guid userId);

        /// <summary>
        /// Update tournaments stats.
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <param name="stats"></param>
        void UpdateTournamentStats(Guid tournamentId, JObject stats);

		#endregion

		#region Players

		/// <summary>
		/// Get players of tournament.
		/// </summary>
		/// <param name="tournamentId"></param>
		/// <returns></returns>
		IEnumerable<TournamentPlayer> GetTournamentPlayers(Guid tournamentId);

		/// <summary>
		/// Add new tournament player.
		/// </summary>
		/// <param name="player"></param>
	    void AddTournamentPlayer(TournamentPlayer player);

	    /// <summary>
	    /// Remove player from tournament.
	    /// </summary>
	    /// <param name="playerId"></param>
	    void RemoveTournamentPlayer(Guid playerId);

		#endregion

		#region Invites

		/// <summary>
		/// Check if tournament invite exists.
		/// </summary>
		/// <param name="inviteId"></param>
		/// <returns></returns>
		TournamentInvite GetTournamentInvite(Guid inviteId);

        /// <summary>
        /// Find tournament for given player or team.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="teamId"></param>
        /// <returns></returns>
        IEnumerable<TournamentInvite> FindTournamentInvite(Guid userId, Guid teamId);

        /// <summary>
        /// Create new tournament invite.
        /// </summary>
        /// <param name="invite"></param>
        void CreateTournamentInvite(TournamentInvite invite);

        /// <summary>
        /// Use tournament invite by id.
        /// </summary>
        /// <param name="inviteId"></param>
        void UseTournamentInvite(Guid inviteId);

        /// <summary>
        /// Recall tournament invite by id.
        /// </summary>
        /// <param name="inviteId"></param>
        void RecallTournamentInvite(Guid inviteId);

        /// <summary>
        /// Get user tournaments invites.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<TournamentInvite> GetUserInvites(Guid userId);

		/// <summary>
        /// Get tournament invites.
        /// </summary>
        /// <param name="tournamentId"></param>
        /// <returns></returns>
        IEnumerable<TournamentInvite> GetTorunamentInvites(Guid tournamentId);

        /// <summary>
        /// Get tournaments invites for teams.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        IEnumerable<TournamentInvite> GetTeamInvites(Guid teamId);

        #endregion
    }
}