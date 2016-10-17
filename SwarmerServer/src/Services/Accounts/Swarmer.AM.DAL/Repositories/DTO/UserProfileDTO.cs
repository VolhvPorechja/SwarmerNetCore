using System.Data;
using Dapper;
using Newtonsoft.Json;
using Npgsql;
using Swarmer.AM.Contracts.Domain;

namespace Swarmer.AM.DAL.Repositories.DTO
{
	public class UserProfileDTO : UserProfile, SqlMapper.ICustomQueryParameter
	{
		public UserProfileDTO(UserProfile profile) : base(profile.Image, profile.LastName)
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