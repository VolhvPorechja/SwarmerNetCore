using System;
using System.Collections.Generic;
using Swarmer.AM.Contracts.Domain;

namespace Swarmer.AM.Contracts.Repositories
{
    /// <summary>
    /// Contract for teams repository.
    /// </summary>
    public interface TeamsRepositoryContract
    {
        /// <summary>
        /// Get all teams info with pagination.
        /// </summary>
        /// <param name="pageSize">Size of page in pagination.</param>
        /// <param name="pageNumber">Number of page in pagination.</param>
        /// <returns></returns>
        List<TeamInfo> GetAll(int pageSize, int pageNumber);

		/// <summary>
		/// Check is team with id exists.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
	    bool IsTeamExists(Guid id);

        /// <summary>
        /// Get team by team id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Team GetTeamById(Guid id);

		/// <summary>
		/// Check is team with given name already exists.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
	    bool IsTeamWithNameExists(string name);

        /// <summary>
        /// Get team by team name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Team GetTeamByName(string name);

        /// <summary>
        /// Create new team.
        /// </summary>
        /// <param name="creatingTeam"></param>
        void CreateTeam(Team creatingTeam);

        /// <summary>
        /// Update team info.
        /// </summary>
        /// <param name="updatedInfo"></param>
        void UpdateTeam(Team updatedInfo);

        /// <summary>
        /// Block team.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="reason">Blocking reason.</param>
        void BlockTeam(Guid teamId, string reason);

	    /// <summary>
	    /// Get team members.
	    /// </summary>
	    /// <returns></returns>
	    List<TeamMembership> GetTeamMembers(Guid teamId);

	    /// <summary>
	    /// Get user membership.
	    /// </summary>
	    /// <param name="teamId"></param>
	    /// <param name="userId"></param>
	    /// <param name="isOwner"></param>
	    void GiveUserMembership(Guid teamId, Guid userId, bool? isOwner = false);

        /// <summary>
        /// Stop user membership.
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="userId"></param>
        void StopUserMembership(Guid teamId, Guid userId);
    }
}