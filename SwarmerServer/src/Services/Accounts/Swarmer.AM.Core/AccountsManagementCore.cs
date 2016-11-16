using Swarmer.AM.Contracts.Repositories;

namespace Swarmer.AM.Core
{
	public class AccountsManagementCore
	{
	    public AccountsManagementCore(RepositoriesManagerContract reposManager)
	    {
	        AuthenticationApi = new AuthenticationApi(reposManager);
	        UsersApi = new UsersApi(reposManager);
            TeamsApi = new TeamsApi(reposManager);
	    }

	    public AuthenticationApi AuthenticationApi { get; }
		public UsersApi UsersApi { get; }
		public TeamsApi TeamsApi { get; }
	}
}