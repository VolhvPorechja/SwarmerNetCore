using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dommel;
using Swarmer.AM.Contracts.Domain;
using Swarmer.AM.Contracts.Repositories;

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
                        $"SELECT Id, Create, Updated, FirstName, SecondName, Login FROM Users LIMIT {pageSize} OFFSET {pageSize*(pageNumber - 1)}")
                    .ToList();
        }

        public User GetUserById(int id)
        {
            return mConnection.Query<User>("SELECT * FROM Users WHERE Id = @id", new {id}).FirstOrDefault();
        }

        public User GetUserByLogin(string login)
        {
            return mConnection.Query<User>("SELECT * FROM Users WHERE Login = @login", new {login}).FirstOrDefault();
        }

        public void UpdateUser(User updatedInfo)
        {
            mConnection.Update(updatedInfo);
        }

        public void CreateUser(User creatingUser)
        {
            mConnection.Insert(creatingUser);
        }

        public void BlockUser(string login, string reason)
        {
            throw new NotImplementedException();
        }

        public List<TeamMembership> GetUserTeams(int id)
        {
            return
                mConnection.Query<TeamMembership>("SELECT * FROM TeamsMembership WHERE UserId = @id", new {id}).ToList();
        }

        public void RequestMembership(int userId, int teamId)
        {
            mConnection.Insert(new TeamMembership
            {
                Created = DateTime.Now,
                TeamId = teamId,
                UserId = userId,
                Data = new TeamMembershipData
                {
                    Approuved = false,
                    IsActive = false
                }
            });
        }

        public void LeaveTeam(int userId, int teamId)
        {
            mConnection.Delete(
                mConnection.Query<TeamMembership>(
                    "SELECT Id FROM TeamsMembership WHERE UserId = @userId AND TeamId = @teamId", new {userId, teamId}));
        }
    }
}