using System.Collections.Generic;
using Swarmer.Contracts.Domain;

namespace Swarmer.Contracts.Repositories
{
    public interface UsersRepositoryContract
    {
        List<User> GetAll();
    }
}