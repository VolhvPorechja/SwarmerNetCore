using System.Data;
using Dapper;
using Newtonsoft.Json;
using Npgsql;
using Swarmer.AM.Contracts.Domain;

namespace Swarmer.AM.DAL.Repositories.DTO
{
	public class TeamProfileDTO : TeamProfile, SqlMapper.ICustomQueryParameter
	{
		public TeamProfileDTO(string Icon = null, string Image = null, int? NumberOfWins = null, int? TotalGames = null) : base(Icon, Image, NumberOfWins, TotalGames)
		{
		}

		public TeamProfileDTO(TeamProfile profile) : base(profile.Icon, profile.Image, profile.NumberOfWins, profile.TotalGames)
		{
			
		}

		public void AddParameter(IDbCommand command, string name)
		{
			var param = (NpgsqlParameter)command.CreateParameter();
			param.ParameterName = name;
			param.Value = JsonConvert.SerializeObject(this);
			param.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Jsonb;
			command.Parameters.Add(param);
		}
	}
}