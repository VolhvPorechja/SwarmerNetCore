using System;
using System.Data;
using Dapper;
using Newtonsoft.Json;
using Npgsql;
using Swarmer.AM.Contracts.Domain;

namespace Swarmer.AM.DAL.Repositories.DTO
{
	public class TeamMembershipDataDTO : TeamMembershipData, SqlMapper.ICustomQueryParameter
	{
		public TeamMembershipDataDTO(bool? Approuved = null, bool? IsActive = null, DateTime? StartDate = null) : base(Approuved, IsActive, StartDate)
		{
		}

		public TeamMembershipDataDTO(TeamMembershipData data) : base(data.Approuved, data.IsActive, data.StartDate)
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