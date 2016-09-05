using System;
using System.Collections.Generic;
using System.Linq;

using Swarmer.Contracts.Domain;

namespace SwarmerServer.Repositories
{
    public class UsersRepository
    {
        private readonly List<User> mUsers = new List<User>
        {
            new User
                {
                    Id = 1,
                    FirstName = "Maxim",
                    SecondName = "Sidorov",
                    Login = "VolhvPorechja",
                    Country = "Russia",
                    BirthDate = new DateTime(2016,5,26),
                    Gender = "male",
                    Role = "ADMIN",
                    AvailableEntries = new List<string> { "LP", "FB", "VK" },
                    Created = new DateTime(2016,9,1,12,0,0),
                    TimeZone = "GMT+03"
                }
        };

        public List<User> GetAll()
        {
            return mUsers.ToList();
        }
    }
}