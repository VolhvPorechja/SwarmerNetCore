using System;
using Dapper;
using Npgsql;
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

		public static void RunCommand(string connectionString, Action<NpgsqlCommand> command)
		{
			using (var connection = new NpgsqlConnection(connectionString))
			{
				connection.Open();

				using (var comm = new NpgsqlCommand { Connection = connection })
					command(comm);

				connection.Close();
			}
		}
	}
}