using Dapper;
using Swarmer.AM.DAL.TypesHandlers;

namespace Swarmer.AM.DAL
{
	public static class AccountsDal
	{
		public static void Init()
		{
			SqlMapper.AddTypeHandler(new ProfileTypeHandler());
			SqlMapper.AddTypeHandler(new TeamMembershipHandler());
			SqlMapper.AddTypeHandler(new TeamProfileHandler());
		}
	}
}