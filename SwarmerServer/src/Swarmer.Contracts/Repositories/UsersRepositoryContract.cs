using System.Collections.Generic;
using Swarmer.Contracts.Domain;

namespace Swarmer.Contracts.Repositories
{
    /// <summary>
    /// Contract for repository of users.
    /// </summary>
    public interface UsersRepositoryContract
    {
        /// <summary>
        /// Get all users with pagination.
        /// </summary>
        /// <returns></returns>
        List<UserInfo> GetAll(int pageSize, int pageNumber);

        /// <summary>
        /// Get user by user id.
        /// </summary>
        /// <param name="id">Id of getting user.</param>
        /// <returns></returns>
        User GetUserById(int id);

        /// <summary>
        /// Get user by user login.
        /// </summary>
        /// <param name="login">Getting user login.</param>
        /// <returns></returns>
        User GetUserByLogin(string login);

        /// <summary>
        /// Update user information.
        /// </summary>
        /// <param name="updatedInfo"></param>
        void UpdateUser(User updatedInfo);

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="creatingUser"></param>
        void CreateUser(User creatingUser);

        /// <summary>
        /// Block user.
        /// </summary>
        /// <param name="login">Blocking user login.</param>
        /// <param name="reason">Blocking reason.</param>
        void BlockUser(string login, string reason);

        /// <summary>
        /// Get user teams by user id.
        /// </summary>
        /// <param name="id">User team.</param>
        /// <returns></returns>
        List<TeamMembership> GetUserTeams(int id);

        /// <summary>
        /// Create user membership (not approuved).
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="teamName"></param>
        void CreateMembership(string userLogin, string teamName);

        /// <summary>
        /// Remove user team membership.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="teamName"></param>
        void LeaveTeam(string userLogin, string teamName);
    }
}