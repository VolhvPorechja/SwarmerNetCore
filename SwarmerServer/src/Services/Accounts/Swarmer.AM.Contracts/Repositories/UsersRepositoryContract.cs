using System;
using System.Collections.Generic;
using Swarmer.AM.Contracts.Contracts;
using Swarmer.AM.Contracts.Domain;

namespace Swarmer.AM.Contracts.Repositories
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
		/// Check is user with give id exists.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		bool IsUserExists(Guid userId);

		/// <summary>
		/// Check if login exists in storage.
		/// </summary>
		/// <param name="login"></param>
		/// <returns></returns>
		bool IsLoginExists(string login);

		/// <summary>
		/// Checl is email exists in storage.
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		bool IsEmailExists(string email);

		/// <summary>
		/// Get user by user id.
		/// </summary>
		/// <param name="id">Id of getting user.</param>
		/// <returns></returns>
		User GetUserById(Guid id);

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
		UserInfo UpdateUser(User updatedInfo);

        /// <summary>
        /// Adding user authentication data.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <param name="secret"></param>
	    void AddAuthenticationData(Guid userId, string type, string secret);

        /// <summary>
        /// Get authentication data by type.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
	    AuthneticationData GetAuthenticationData(Guid userId, string type);
        
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
		/// If login alreay exists.
		/// </summary>
		/// <param name="login"></param>
		/// <returns></returns>
		bool IsLoginExist(string login);
        
		/// <summary>
		/// Get user teams by user id.
		/// </summary>
		/// <param name="id">User team.</param>
		/// <returns></returns>
		List<TeamMembership> GetUserTeams(Guid id);

		/// <summary>
		/// Get user team membership info.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="teamId"></param>
		/// <returns></returns>
		TeamMembership GetUserTeamMembershipData(Guid userId, Guid teamId);

		/// <summary>
		/// Check is user is member team.
		/// </summary>
		/// <param name="userId">Id of checking user.</param>
		/// <param name="teamId">Id of checking team.</param>
		bool IsMembershipOfTeam(Guid userId, Guid teamId);
		
		/// <summary>
		/// Create user membership (not approuved).
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="teamId"></param>
		void RequestMembership(Guid userId, Guid teamId);
		
		/// <summary>
		/// Remove user team membership.
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="teamId"></param>
		void LeaveTeam(Guid userId, Guid teamId);
	}
}