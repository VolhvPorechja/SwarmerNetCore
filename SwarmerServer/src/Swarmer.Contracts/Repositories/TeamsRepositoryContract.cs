using System.Collections.Generic;
using Swarmer.Contracts.Domain;

namespace Swarmer.Contracts.Repositories
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
        /// Get team by team id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Team GetTeamById(int id);

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
        /// <param name="teamName">Team name.</param>
        /// <param name="reason">Blocking reason.</param>
        void BlockTeam(string teamName, string reason);

        /// <summary>
        /// Get team members.
        /// </summary>
        /// <returns></returns>
        List<TeamMembership> GetTeamMembers();

        /// <summary>
        /// Get user membership.
        /// </summary>
        /// <param name="teamName">Team name.</param>
        /// <param name="userLogin">Login of user to which membership will be given.</param>
        void GiveUserMembership(string teamName, string userLogin);

        /// <summary>
        /// Stop user membership.
        /// </summary>
        /// <param name="teamName"></param>
        /// <param name="userLogin"></param>
        void StopUserMembership(string teamName, string userLogin);
    }
}