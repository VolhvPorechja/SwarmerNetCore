using System.Data;
using Newtonsoft.Json;
using Npgsql;
using Swarmer.TM.Contracts.Domain;

namespace Swarmer.TM.DAL.DTO
{
    public class PartyDataDTO: PartyData
    {
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